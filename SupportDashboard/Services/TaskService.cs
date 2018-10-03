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
        HttpClient client = new HttpClient();

        public async Task<SupportTask> Get(int id)
        {
            client.BaseAddress = new Uri(Properties.Settings.Default.ApiRoot);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            SupportTask task = null;
            HttpResponseMessage responce = await client.GetAsync("api/tasks/{id}");

            if (responce.IsSuccessStatusCode)
            {
                task = await responce.Content.ReadAsAsync<SupportTask>();
            }

            return task;
        }

        public async Task<List<SupportTask>> GetAll()
        {
            client.BaseAddress = new Uri(Properties.Settings.Default.ApiRoot);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List<SupportTask> tasks = null;
            HttpResponseMessage responce = await client.GetAsync("api/tasks");

            if (responce.IsSuccessStatusCode)
            {
                tasks = await responce.Content.ReadAsAsync<List<SupportTask>>();
            }

            return tasks;
        }
    }
}