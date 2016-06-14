using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    { 
        private readonly IDisqusRequestProcessor _requestProcessor;
        private DisqusAuthMethod _authMethod;
        private string _key;

        public DisqusApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            _requestProcessor = requestProcessor;
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

        public async Task<DisqusResponse<DisqusUser>> GetDetailsAsync(int userId, string accessToken = null)
        {
            var parameters = AddAuthenticationParameters();
            parameters.Add("user", userId.ToString(CultureInfo.InvariantCulture));
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                parameters.Add("access_token", accessToken);
            }

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusUser>> GetDetailsAsync(string username, string accessToken = null)
        {
            var parameters = AddAuthenticationParameters();
            parameters.Add("user:username", username);
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                parameters.Add("access_token", accessToken);
            }

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.Details, parameters)
                .ConfigureAwait(false);
        }
    }
}