using System.Net.Http;

namespace Tweetiment.Abstractions.Core
{
    public interface IApiRequest
    {
        string RequestRoute { get; set; }
        HttpMethod HttpMethodType { get; set; }
        object PayloadObject { get; set; }
    }
}
