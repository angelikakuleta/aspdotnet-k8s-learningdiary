using LearningDiary.WebUI.Extensions;
using LearningDiary.WebUI.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LearningDiary.WebUI.Clients
{
    public class SavePointClient : ISavePointClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<SavePointClient> _logger;

        public SavePointClient(HttpClient client, ILogger<SavePointClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IList<SavePointVM>> GetAll(string nickname)
        {
            var response = await _client.GetAsync($"api/SavePoints?nickname={nickname}");
            Log(response);

            return response.ContentAsType<IList<SavePointVM>>();
        }

        public async Task<SavePointDetailsVM> Get(Guid id)
        {
            var response = await _client.GetAsync($"api/SavePoints/{id}");
            Log(response);

            return response.ContentAsType<SavePointDetailsVM>();
        }

        public async Task Add(CreateSavePointVM model)
        {
            var data = ContetntToJson(model);
            var response = await _client.PostAsync($"api/SavePoints", data);
            Log(response);
        }

        public async Task Update(UpdateSavePointVM model)
        {
            var data = ContetntToJson(model);
            var response = await _client.PutAsync($"api/SavePoints/{model.Id}", data);
            Log(response);
        }

        public async Task Delete(Guid? id)
        {
            var response = await _client.DeleteAsync($"api/SavePoints/{id}");
            Log(response);
        }

        private void Log(HttpResponseMessage response)
        {
            _logger.LogInformation($"Call to {response.RequestMessage.RequestUri} ended with status code {response.StatusCode}");
        }

        private StringContent ContetntToJson(object model)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
