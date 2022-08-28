using PhoneDirectory.Shared.DTOs;
using PhoneDirectory.Shared.Entities;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace PhoneDirectory.Client.Rest
{
    public class RestService : IRestService
    {

        public HttpClient HttpClient { get; }
        public string TOKENKEY { get; set; }

        private JsonSerializerOptions defaultOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, ReferenceHandler = ReferenceHandler.Preserve };

        public RestService(HttpClient httpClient)
        {
            HttpClient = httpClient;

            httpClient.BaseAddress = new Uri("http://localhost:7002/api/");
        }



        public async Task<T> GetAsync<T>(string url)
        {
            if(string.IsNullOrEmpty(TOKENKEY))
                return await GetAnonymousAsync<T>(url);
            else
                return await GetAsync<T?>(url, TOKENKEY);
        }




        private async Task<T?>GetAnonymousAsync<T>(string url)
        {
            var response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), defaultOptions);
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task<T?> GetAsync<T>(string url, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), defaultOptions);
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }


        public async Task<T> PostAsync<T>(string url, object data)
        {
            if (string.IsNullOrEmpty(TOKENKEY)) 
            {
                return await PostAsyncAnonymous<T>(url, data);
            }
            else
                return await PostAsync<T>(url, data, TOKENKEY);

        }

        public async Task<T> PutAsync<T>(string url, object data)
        {
            if (string.IsNullOrEmpty(TOKENKEY))
            {
                return await PutAsyncAnonymous<T>(url, data);
            }
            else
                return await PutAsync<T>(url, data, TOKENKEY);

        }

        private async Task<T?> PostAsync<T>(string url, object data, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            string jsonData = JsonSerializer.Serialize(data, defaultOptions);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url.TrimStart('/'), stringContent);

            if (response.IsSuccessStatusCode)
            {
                string returnJson = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(returnJson))
                    return JsonSerializer.Deserialize<T?>(await response.Content.ReadAsStringAsync(), defaultOptions);
                else
                    return default(T);
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task<T?> PostAsyncAnonymous<T>(string url, object data)
        {
            string jsonData = JsonSerializer.Serialize(data, defaultOptions);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url.TrimStart('/'), stringContent);

            if (response.IsSuccessStatusCode)
            {
                string returnJson = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(returnJson))
                    return JsonSerializer.Deserialize<T?>(await response.Content.ReadAsStringAsync(), defaultOptions);
                else
                    return default(T);
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task<T?> PutAsync<T>(string url, object data, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            string jsonData = JsonSerializer.Serialize(data, defaultOptions);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await HttpClient.PutAsync(url.TrimStart('/'), stringContent);

            if (response.IsSuccessStatusCode)
            {
                string returnJson = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(returnJson))
                    return JsonSerializer.Deserialize<T?>(await response.Content.ReadAsStringAsync(), defaultOptions);
                else
                    return default(T);
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task<T?> PutAsyncAnonymous<T>(string url, object data)
        {
            string jsonData = JsonSerializer.Serialize(data, defaultOptions);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await HttpClient.PutAsync(url.TrimStart('/'), stringContent);

            if (response.IsSuccessStatusCode)
            {
                string returnJson = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(returnJson))
                    return JsonSerializer.Deserialize<T?>(await response.Content.ReadAsStringAsync(), defaultOptions);
                else
                    return default(T);
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }


        public async Task DeleteAsync(string url)
        {
            if (string.IsNullOrEmpty(TOKENKEY))
            {
                await DeleteAnonymousAsync(url);
            }
            else
                await DeleteAsync(url, TOKENKEY);

        }

        private async Task DeleteAnonymousAsync(string url)
        {
            var response = await HttpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task DeleteAsync(string url, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = await HttpClient.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
