using System.Net.Http;

namespace Tweetiment.Abstractions.Core
{
    public class ApiRequest : IApiRequest
    {
        public string RequestRoute { get; set; }
        public HttpMethod HttpMethodType { get; set; }
        public object PayloadObject { get; set; }
    }
}
