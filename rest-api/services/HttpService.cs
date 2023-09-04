using System;
using System.Net.Http;
using System.Threading.Tasks;
using rest_api.interfaces;

namespace rest_api.services
{
    public class HttpService:IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetJsonDataAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                return jsonData;
            }
            else
            {
                throw new Exception($"HTTP request failed with status code {response.StatusCode}");
            }
        }
    }
}
