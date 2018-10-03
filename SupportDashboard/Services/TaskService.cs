using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SupportTask = SupportDashboard.BusinessLogic.Models.Task;

namespace SupportDashboard.Services
{
    public class TaskService : ISupportDashboard<SupportTask>
    {
        private static HttpClient _httpClient;

        static TaskService()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(Properties.Settings.Default.ApiRoot);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<SupportTask> Get(int id)
        {
            SupportTask task = null;

            string url = $"api/Tasks/{id}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                task = await response.Content.ReadAsAsync<SupportTask>();
            }

            return task;
        }

        public async Task<List<SupportTask>> GetAll()
        {
            List<SupportTask> tasks = null;

            HttpResponseMessage response = await _httpClient.GetAsync("api/tasks");

            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadAsAsync<List<SupportTask>>();
            }

            return tasks;
        }

        public async Task Delete(int id)
        {
            string url = $"api/tasks/{id}";

            HttpResponseMessage response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Delete is not success");
            }
        }

        public async Task Add(SupportTask item)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/tasks/create", item);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Adding is not success");
            }
        }

        public async Task Update(SupportTask item)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<SupportTask>("api/tasks/create", item);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Updateing is not success");
            }
        }
    }
}