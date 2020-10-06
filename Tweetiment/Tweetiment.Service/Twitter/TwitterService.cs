using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetiment.Abstractions.Core;
using Tweetiment.Abstractions.Request;
using Tweetiment.Abstractions.Response.TwitterSearchResponse;
using Tweetiment.Core.Rest;

namespace Tweetiment.Service.Twitter
{
    public class TwitterService : ITwitterService
    {
        private readonly IApiClient<IApiRequest> _apiClient;
        private readonly string _apiEndpoint;

        public TwitterService(IApiClient<IApiRequest> apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _apiEndpoint = configuration["TwitterApi:BaseUrl"].TrimEnd('/');
        }

        public async Task<TwitterSearchResponse> SearchForTweetsAsync(TwitterSearchRequest request)
        {
            var response = new TwitterSearchResponse();

            if (string.IsNullOrWhiteSpace(request.Query))
            {
                response.Error = ErrorHandler.GenerateError("Search term cannot be empty");
                return response;
            }

            var builtRequestPath = BuildSearchRequest(ref request);
            request.RequestRoute = $"{_apiEndpoint}/tweets/search/recent?{builtRequestPath}";

            var apiResponse = await _apiClient.GetAsync<TwitterSearchResponse>(request);

            return apiResponse;
        }

        private string BuildSearchRequest(ref TwitterSearchRequest request)
        {
            var queryBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(request.NextToken))
            {
                queryBuilder.Append($"&next_token={request.NextToken}");
            }

            //Twitter API v2 limits the free requests min:10 and max:100 per request.
            //forcing to minimum and maximum is better than failing the entire request.
            if (request.MaxResults < 10)
            {
                queryBuilder.Append("&max_results=10");
            }
            else if (request.MaxResults > 100)
            {
                queryBuilder.Append("&max_results=100");
            }

            if (request.TweetFields != null && request.TweetFields.Any())
            {
                var concatenatedTweetFields = string.Join(',', request.TweetFields);
                queryBuilder.Append($"&tweet.fields={concatenatedTweetFields}");
            }

            if (request.UserFields != null && request.UserFields.Any())
            {
                var concatenatedUserFields = string.Join(',', request.UserFields);
                queryBuilder.Append($"&user.fields={concatenatedUserFields}");
            }

            queryBuilder.Append($"&query={request.Query}");

            return queryBuilder.ToString();
        }

    }
}
