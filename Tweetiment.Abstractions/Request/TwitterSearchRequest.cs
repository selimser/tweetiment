using System.Collections.Generic;
using Tweetiment.Abstractions.Core;

namespace Tweetiment.Abstractions.Request
{
    public class TwitterSearchRequest : ApiRequest
    {
        /// <summary>
        /// Search string for the tweet, which corresponds to the "query" parameter
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Limits the number of tweets to be returned on each request, corresponds to the "max_results" parameter
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The cursor value for fetching tweets consecutively, corresponds to the "next_token" parameter
        /// </summary>
        public string NextToken { get; set; }

        /// <summary>
        /// The tweet fields which will be included in the api response, corresponds to the "tweet.fields" parameter
        /// </summary>
        public IEnumerable<string> TweetFields { get; set; }

        /// <summary>
        /// The user fields which will be included in the api response, corresponds to the "user.fields" parameter
        /// </summary>
        public IEnumerable<string> UserFields { get; set; }
    }
}
