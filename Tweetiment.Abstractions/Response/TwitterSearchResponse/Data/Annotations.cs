using System.Runtime.Serialization;

namespace Tweetiment.Abstractions.Response.TwitterSearchResponse.Data
{
    [DataContract]
    public class Annotations
    {
        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "end")]
        public int End { get; set; }

        [DataMember(Name = "probability")]
        public decimal Probability { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
