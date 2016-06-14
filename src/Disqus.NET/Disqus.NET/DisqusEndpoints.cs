namespace Disqus.NET
{
    /// <summary>
    /// Endpoints for Disqus API  3.0
    /// </summary>
    public class DisqusEndpoints
    {
        private const string ApiUrl = "https://disqus.com/api/3.0/";
        private const string OutputType = ".json";

        public static class Users
        {
            private const string Category = "users/";

            public const string Details = ApiUrl + Category + "details" + OutputType;
        }
    }
}
