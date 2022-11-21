using System.Threading.Tasks;
using Tweetiment.Abstractions.Core;

namespace Tweetiment.Core.Rest
{
    public interface IApiClient<in TApiRequest> where TApiRequest : IApiRequest
    {
        //methods needs to support cancellation - possibly a cancellation token needs to be injected.
        Task<TApiResponse> PostAsync<TApiResponse>(TApiRequest apiRequest);
        Task<TApiResponse> GetAsync<TApiResponse>(TApiRequest apiRequest);
    }
}
