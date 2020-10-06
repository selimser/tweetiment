using System.Threading.Tasks;
using Tweetiment.Abstractions.Request;
using Tweetiment.Abstractions.Response.TwitterSearchResponse;

namespace Tweetiment.Service.Twitter
{
    public interface ITwitterService
    {
        Task<TwitterSearchResponse> SearchForTweetsAsync(TwitterSearchRequest request);
    }
}
