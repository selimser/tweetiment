using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tweetiment.Abstractions.Response.TwitterSearchResponse.Data
{
    [DataContract]
    public class Entities
    {
        [DataMember(Name = "annotations")]
        public IEnumerable<Annotations> Annotations { get; set; }
    }
}
