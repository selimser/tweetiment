namespace Tweetiment.Abstractions.Core
{
    public static class ErrorHandler
    {
        public static Error GenerateError(string message, int? httpStatusCode = null)
        {
            return new Error
            {
                Message = message,
                HttpResponseCode = httpStatusCode
            };
        }
    }
}
