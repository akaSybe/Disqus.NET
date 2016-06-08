using System;
using System.Collections.Generic;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    {
        private DisqusAuthMethod _authMethod;
        private string _key;

        public DisqusApi(DisqusAuthMethod authMethod, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            _authMethod = authMethod;
            _key = key;
        }

        public void SetDisqusAuth(DisqusAuthMethod authMethod, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            _authMethod = authMethod;
            _key = key;
        }

        internal Dictionary<string, string> AddAuthenticationParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(_authMethod == DisqusAuthMethod.PublicKey ? "api_key" : "api_secret", _key);

            return parameters;
        }
    }
}