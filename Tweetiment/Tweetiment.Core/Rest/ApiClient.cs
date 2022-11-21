using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tweetiment.Abstractions.Core;
using Tweetiment.Core.Serialization;
using Tweetiment.Core.Shared;

namespace Tweetiment.Core.Rest
{
    public class ApiClient<TApiRequest> : IApiClient<TApiRequest> where TApiRequest : IApiRequest
    {
        private readonly HttpMethod[] serializableMethods;
        private readonly HttpClient _httpClient;
        private protected readonly IHttpSerialiser _httpSerialiser;

        public ApiClient(HttpClient httpClient, IHttpSerialiser httpSerialiser)
        {
            _httpClient = httpClient;
            _httpSerialiser = httpSerialiser;

            serializableMethods = new[] { HttpMethod.Post, HttpMethod.Put, HttpMethod.Patch };
        }

        public async Task<TApiResponse> GetAsync<TApiResponse>(TApiRequest apiRequest)
        {
            apiRequest.HttpMethodType = HttpMethod.Get;
            return await InvokeAsync<TApiResponse>(CreateApiRequest(apiRequest), apiRequest);
        }

        public async Task<TApiResponse> PostAsync<TApiResponse>(TApiRequest apiRequest)
        {
            apiRequest.HttpMethodType = HttpMethod.Post;
            return await InvokeAsync<TApiResponse>(CreateApiRequest(apiRequest), apiRequest);
        }

        private async Task<TResponse> InvokeAsync<TResponse>(HttpRequestMessage httpRequest, TApiRequest apiRequest)
        {
            using (var apiResponse = await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseContentRead))
            {
                apiResponse.EnsureSuccessStatusCode();
                var responseContent = await apiResponse.Content.ReadAsStringAsync();
                return _httpSerialiser.Deserialise<TResponse>(responseContent);
            }
        }

        private HttpRequestMessage CreateApiRequest(TApiRequest outgoingRequest)
        {
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(outgoingRequest.RequestRoute)
            };

            /* POST, PUT and PATCH methods can have a payload, so reuqest needs to be serialized
               https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods */
            if (serializableMethods.Contains(outgoingRequest.HttpMethodType))
            {
                var payloadContent = SerializePayload();
                requestMessage.Content = new StringContent(payloadContent, Encoding.UTF8, HttpMimeTypes.ApplicationJson);
            }

            return requestMessage;

            string SerializePayload()
            {
                return _httpSerialiser.Serialise(outgoingRequest.PayloadObject);
            }

        }
    }
}
