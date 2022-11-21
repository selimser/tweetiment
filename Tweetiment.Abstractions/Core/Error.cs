namespace Tweetiment.Abstractions.Core
{
    public class Error
    {
        public string Message { get; set; }
        public int? HttpResponseCode { get; set; }
    }
}
