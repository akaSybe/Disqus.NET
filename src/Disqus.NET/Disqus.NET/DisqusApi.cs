using System.Collections.Generic;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    {
        private DisqusAuth _auth;

        public DisqusApi(DisqusAuth auth)
        {
            _auth = auth;
        }

        public void SetDisqusAuth(DisqusAuth auth)
        {
            _auth = auth;
        }

        internal Dictionary<string, string> AddAuthenticationParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("api_key", _auth.ApiKey);
            parameters.Add("api_secret", _auth.ApiSecret);

            return parameters;
        }
    }
}