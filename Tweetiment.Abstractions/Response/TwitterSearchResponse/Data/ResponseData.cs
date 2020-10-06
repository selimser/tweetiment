using System.Runtime.Serialization;

namespace Tweetiment.Abstractions.Response.TwitterSearchResponse.Data
{
    [DataContract]
    public class ResponseData
    {
        [DataMember(Name = "public_metrics")]
        public PublicMetrics PublicMetrics { get; set; }

        [DataMember(Name = "entities")]
        public Entities Entities { get; set; }

        [DataMember(Name = "possibly_sensitive")]
        public bool PossiblySensitive { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "author_id")]
        public string AuthorId { get; set; }

        [DataMember(Name = "conversation_id")]
        public string ConversationId { get; set; }

        [DataMember(Name = "text")]
        public string TweetContents { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "lang")]
        public string Language { get; set; }
    }
}
