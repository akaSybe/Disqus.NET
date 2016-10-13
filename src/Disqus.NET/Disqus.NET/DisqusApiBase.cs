using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Disqus.NET
{
    public class DisqusApiBase
    {
        protected readonly IDisqusRequestProcessor RequestProcessor;
        public DisqusAuth Auth { get; }

        protected class DisqusParameters
        {
            private readonly List<KeyValuePair<string, string>> _parameters;

            public DisqusParameters(DisqusAuthMethod authMethod, string key)
            {
                _parameters = new List<KeyValuePair<string, string>>();
                _parameters.Add(new KeyValuePair<string, string>(authMethod == DisqusAuthMethod.PublicKey ? "api_key" : "api_secret", key));
            }

            public static implicit operator Collection<KeyValuePair<string, string>>(DisqusParameters obj)
            {
                var parameters = new KeyValuePair<string, string>[obj._parameters.Count];
                obj._parameters.CopyTo(parameters, 0);
                return new Collection<KeyValuePair<string, string>>(parameters);
            }

            /// <summary>
            /// Ignores parameter if value is null
            /// </summary>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public DisqusParameters WithOptionalParameter(string name, object value)
            {
                if (value != null)
                {
                    _parameters.Add(new KeyValuePair<string, string>(name, value.ToString()));
                }

                return this;
            }

            public DisqusParameters WithParameter(string name, object value)
            {
                _parameters.Add(new KeyValuePair<string, string>(name, value.ToString()));
                return this;
            }

            public DisqusParameters WithMultipleParameters(string name, string[] values)
            {
                foreach (var value in values)
                {
                    _parameters.Add(new KeyValuePair<string, string>(name, value));
                }
                return this;
            }

            public DisqusParameters WithMultipleParameters(ICollection<KeyValuePair<string, string>> parameters)
            {
                _parameters.AddRange(parameters);

                return this;
            }
        }
        protected DisqusParameters Parameters => new DisqusParameters(Auth.AuthMethod, Auth.ApiKey);

        public DisqusApiBase(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
        {
            if (requestProcessor == null)
            {
                throw new ArgumentNullException(nameof(requestProcessor));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            RequestProcessor = requestProcessor;
            Auth = new DisqusAuth(authMethod, key);
        }
    }
}
