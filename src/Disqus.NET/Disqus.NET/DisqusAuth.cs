namespace Disqus.NET
{
    public class DisqusAuth
    {
        /// <summary>
        /// server-side API key or public-facing JavaScript API key
        /// </summary>
        public string ApiKey { get; private set; }

        public DisqusAuthMethod AuthMethod { get; private set; }

        public DisqusAuth(DisqusAuthMethod authMethod, string apiKey)
        {
            AuthMethod = authMethod;
            ApiKey = apiKey;
        }
    }
}
