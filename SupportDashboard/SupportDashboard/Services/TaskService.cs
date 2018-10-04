using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using SupportDashboard.BusinessLogic.Models;
using DashboardTask = SupportDashboard.BusinessLogic.Models.Task;

namespace SupportDashboard.Services
{
    public class TaskService : ISupportDashboardService<DashboardTask>
    {
        HttpClient client = new HttpClient();

        public async Task<DashboardTask> Get(int id)
        {
            throw new NotImplementedException();
            // Update port # in the following line.
            client.BaseAddress = new Uri(Properties.Settings.Default.ApiRoot);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List<DashboardTask> contacts = null;
            HttpResponseMessage responce = await client.GetAsync("api/contact");

            if (responce.IsSuccessStatusCode)
            {
               // contacts = await responce.Content.ReadAsAsync<List<DashboardTask>>();
            }

            //return contacts;
        }

        public Task<List<DashboardTask>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}