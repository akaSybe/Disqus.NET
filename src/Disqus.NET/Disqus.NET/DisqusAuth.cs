namespace Disqus.NET
{
    public class DisqusAuth
    {
        /// <summary>
        /// public-facing JavaScript API key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// server-side API key
        /// </summary>
        public string ApiSecret { get; set; }
    }
}
