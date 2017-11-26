using System.Collections.Generic;
using System.Threading.Tasks;
using EyeCare.Helpers;
using EyeCare.Models;

namespace EyeCare.Services
{
    public class DiagnosesClient
    {
        private string BaseUriString { get; } = "http://eye-care.azurewebsites.net/api/";

        #region CRUD

        public async Task<IList<Diagnosis>> GetDiagnosesAsync()
        {
            var movies =
                await JsonRestApi.GetAsync<List<Diagnosis>>($"{BaseUriString}diagnoses");

            return movies;
        }

        public async Task<Diagnosis> GetDiagnosisAsync(string id)
        {
            var movie =
                await JsonRestApi.GetAsync<Diagnosis>($"{BaseUriString}diagnoses/{id}");

            return movie;
        }

        public async Task AddDiagnosisAsync(Diagnosis diagnoses)
        {
            await JsonRestApi.PostAsync<Diagnosis>($"{BaseUriString}diagnoses", diagnoses);
        }

        public async Task UpdateDiagnosisAsync(Diagnosis diagnosis, string id)
        {
            await JsonRestApi.PutAsync<Diagnosis>($"{BaseUriString}diagnoses/{id}", diagnosis);
        }

        public async Task RemoveDiagnosisAsync(string id)
        {
            await JsonRestApi.DeleteAsync($"{BaseUriString}diagnoses/{id}");
        }

        #endregion
    }
}