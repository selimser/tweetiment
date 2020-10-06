using System.Collections.Generic;
using System.Runtime.Serialization;
using Tweetiment.Abstractions.Core;
using Tweetiment.Abstractions.Response.TwitterSearchResponse.Data;

namespace Tweetiment.Abstractions.Response.TwitterSearchResponse
{
    [DataContract]
    public class TwitterSearchResponse : BaseResponse
    {
        [DataMember(Name = "data")]
        public IEnumerable<ResponseData> Data { get; set; }
    }
}
