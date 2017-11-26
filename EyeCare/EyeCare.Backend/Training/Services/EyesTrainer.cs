using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using EyeCare.Backend.Training.Models;
using Microsoft.Cognitive.CustomVision;
using Microsoft.Cognitive.CustomVision.Models;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace EyeCare.Backend.Training.Services
{
    public class EyesTrainer
    {
        private readonly string _projectName = "EyeCareProject";

        private string _trainingKey;
        private readonly IFileProvider _fileProvider;

        public TrainingApi TrainingApi { get; private set; }
        public Guid ProjectGuid { get; private set; } 

        public EyesTrainer(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public void SetTrainingKey(string trainingKey)
        {
            _trainingKey = trainingKey;
        }

        /// <summary>
        /// Initialize Model from preloaded Data
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public void InitializeModel()
        {
            if (string.IsNullOrWhiteSpace(_trainingKey))
            {
                throw new Exception("Call SetTrainingKey before training the Model");                    
            }

            var trainingCredentials = new TrainingApiCredentials(_trainingKey);
            TrainingApi = new TrainingApi(trainingCredentials);

            // Check if project already exists
            var projects = TrainingApi.GetProjects();
            var duplicate = projects.FirstOrDefault(p => p.Name == _projectName);
            if (duplicate != null)
            {
                TrainingApi.DeleteProject(duplicate.Id);
            }

            // Create a new CV Project
            var project = TrainingApi.CreateProject(_projectName);

            // Save Project Guid
            ProjectGuid = project.Id;

            // Retrieve Model Initialization Data from Folder "Training"
            var trainings = RetrieveTrainings();

            TrainModel(ref project, trainings);
        }

        /// <summary>
        /// Train a Model given a set of trainings
        /// </summary>
        /// <param name="project"></param>
        /// <param name="trainings"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public void TrainModel(ref ProjectModel project, IList<Models.Training> trainings)
        {
            // Save all Training Tasks to be performed
            //var tagCreationTasks = (from training in trainings
            //        from tag in training.Tags
            //        select TrainingApi.CreateTagAsync(project.Id, tag.ToString(), cancellationToken: token)).
            //    Cast<Task>().ToList();

            var tagNames = trainings.Select(t => t.TagName).Distinct();
            var tagNameToId = new Dictionary<string, Guid>();

            foreach (var tagName in tagNames)
            {
                var tagModel = TrainingApi.CreateTag(project.Id, tagName);
                tagNameToId.Add(tagName, tagModel.Id);
            }

            // Execute Trainings
            //await Task.WhenAny(tagCreationTasks);

            foreach (var training in trainings)
            {
                TrainingApi.CreateImagesFromData(project.Id, training.ImageFileStream,
                     new List<string> {tagNameToId[training.TagName].ToString()});
            }

            //var imageCreationTasks = (from training in trainings
            //    from tag in training.Tags
            //    select TrainingApi.CreateImagesFromDataAsync(project.Id, training.ImageFileStream, new List<string> { tag.ToString() }, cancellationToken: token)).Cast<Task>().ToList();

            //await Task.WhenAny(imageCreationTasks);

            var iterationModel = TrainingApi.TrainProject(project.Id);
            

            // The returned iteration will be in progress, and can be queried periodically to see when it has completed
            while (iterationModel.Status == "Training")
            {
                Thread.Sleep(1000);

                // Re-query the iteration to get it's updated status
                iterationModel = TrainingApi.GetIteration(project.Id, iterationModel.Id);
            }

            iterationModel.IsDefault = true;

            // Complete Training
            TrainingApi.UpdateIteration(project.Id, iterationModel.Id, iterationModel);
        }


        /// <summary>
        /// Retrieve initialization trainings and load up image from File System
        /// </summary>
        /// <returns></returns>
        private IList<Models.Training> RetrieveTrainings()
        {
            var mappingsFileInfo = _fileProvider.GetFileInfo("Training/mappings.json"); // a file under applicationRoot

            var mappingsContent = File.ReadAllText(mappingsFileInfo.PhysicalPath);
            var mappings = JsonConvert.DeserializeObject<List<Models.Training>>(mappingsContent);

            foreach (var mapping in mappings)
            {
                var fullFilePath = Path.Combine("Training/Images", mapping.FileName);

                if (!File.Exists(fullFilePath))
                {
                    throw new Exception($"Training Image {mapping.FileName} not found");
                }

                var imageInfo = _fileProvider.GetFileInfo(fullFilePath);
                mapping.ImageFileStream = imageInfo.CreateReadStream();
            }

            return mappings;
        }

        public IList<Prediction> PredictImage(Stream imageStream)
        {
            var account = TrainingApi.GetAccountInfo();
            var predictionKey = account.Keys.PredictionKeys.PrimaryKey;

            var predictionEndpointCredentials = new PredictionEndpointCredentials(predictionKey);
            var endpoint = new PredictionEndpoint(predictionEndpointCredentials);

            var result = endpoint.PredictImage(ProjectGuid, imageStream);

            return result.Predictions.Select(p => new Prediction
            {
                Tag = Enum.Parse<Models.Training.Tag>(p.Tag),
                Probability = p.Probability
            }).ToList();
        }
    }
}
