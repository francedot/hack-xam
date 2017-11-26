using System;
using System.IO;
using Newtonsoft.Json;

namespace EyeCare.Backend.Training.Models
{
    public class Training
    {
        [JsonIgnore]
        public int TrainingId { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        [JsonProperty(PropertyName = "tagName")]
        public string TagName { get; set; }

        [JsonIgnore]
        public Guid TagId { get; set; }

        [JsonIgnore]
        public string ImageFilePath { get; set; }

        [JsonIgnore]
        public Stream ImageFileStream { get; set; }

        public enum Tag
        {
            Healthy,
            Conjunctivitis,
            Jaundice
        }
    }
}
