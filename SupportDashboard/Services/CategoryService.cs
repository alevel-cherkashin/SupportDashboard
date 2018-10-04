using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SupportDashboard.BusinessLogic.Models;

namespace SupportDashboard.Services
{
    public class CategoryService : ISupportDashboard<Category>
    {
        private static HttpClient _httpClient;

        static CategoryService()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(Properties.Settings.Default.ApiRoot);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async System.Threading.Tasks.Task Add(Category item)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/categories/create", item);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Adding is not success");
            }
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            string url = $"api/categories/{id}";

            HttpResponseMessage response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Delete is not success");
            }
        }

        public async Task<Category> Get(int id)
        {
            Category category = null;

            string url = $"api/categories/{id}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                category = await response.Content.ReadAsAsync<Category>();
            }

            return category;
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> categories = null;

            HttpResponseMessage response = await _httpClient.GetAsync("api/categories");

            if (response.IsSuccessStatusCode)
            {
                categories = await response.Content.ReadAsAsync<List<Category>>();
            }

            return categories;
        }

        public async System.Threading.Tasks.Task Update(Category item)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Category>("api/categories/update", item);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Updateing is not success");
            }
        }
    }
}