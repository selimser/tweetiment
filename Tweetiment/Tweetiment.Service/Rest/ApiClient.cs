using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tweetiment.Service.Rest
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;
        private IConfiguration _configuration;
        private readonly string _baseUrl;

        public ApiClient(IConfiguration configuration)
        {
            _baseUrl = _configuration["TwitterApi:BaseUrl"];
            _client = new HttpClient()
            {
                BaseAddress = new Uri(_baseUrl),
                Timeout = TimeSpan.FromSeconds(30),
            };
            
            

            _client.DefaultRequestHeaders.Add("Accept", "*/*");
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            _client.DefaultRequestHeaders.Add("Connection", "keep-alive");


            _configuration = configuration;

            
        }

        private void AttachRequestHeaders()
        {

        }

        public void DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAsync(string path)
        {
            var response = await _client.GetAsync($"{_baseUrl}/{path}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public void PostAsync()
        {
            throw new NotImplementedException();
        }

        public void PutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
