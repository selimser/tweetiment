using System.Runtime.Serialization;

namespace Tweetiment.Abstractions.Response.TwitterSearchResponse.Data
{
    [DataContract]
    public class PublicMetrics
    {
        [DataMember(Name = "retweet_count")]
        public int RetweetCount { get; set; }

        [DataMember(Name = "reply_count")]
        public int ReplyCount { get; set; }

        [DataMember(Name = "like_count")]
        public int LikeCount { get; set; }

        [DataMember(Name = "quote_count")]
        public int QuoteCount { get; set; }
    }
}
