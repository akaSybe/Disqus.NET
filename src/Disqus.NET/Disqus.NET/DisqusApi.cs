using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    {
        private class DisqusParameters
        {
            private List<KeyValuePair<string, string>> _parameters;

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
            public DisqusParameters WithOptionalParameter(string name, string value)
            {
                if (value != null)
                {
                    _parameters.Add(new KeyValuePair<string, string>(name, value));
                }

                return this;
            }

            public DisqusParameters WithParameter(string name, object value)
            {
                _parameters.Add(new KeyValuePair<string, string>(name, value.ToString()));
                return this;
            }
        }

        private string _key;
        private DisqusAuthMethod _authMethod;
        private readonly IDisqusRequestProcessor _requestProcessor;

        private DisqusParameters Parameters
        {
            get
            {
                // required for thread-safety
                return new DisqusParameters(_authMethod, _key);
            }
        }

        public DisqusApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            _authMethod = authMethod;
            _key = key;
            _requestProcessor = requestProcessor;
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

        public async Task<DisqusResponse<DisqusUser>> GetDetailsAsync(int userId, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user", userId.ToString())
                .WithOptionalParameter("access_token", accessToken);
                
            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusUser>> GetDetailsAsync(string username, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user:username", username)
                .WithOptionalParameter("access_token", accessToken);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task FollowAsync(int userId, string accessToken)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target", userId.ToString())
                .WithOptionalParameter("access_token", accessToken);

            await _requestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task FollowAsync(string username, string accessToken)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target:username", username)
                .WithOptionalParameter("access_token", accessToken);

            await _requestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task UnfollowAsync(int userId, string accessToken)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target", userId.ToString())
                .WithOptionalParameter("access_token", accessToken);

            await _requestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Unfollow, parameters)
                .ConfigureAwait(false);
        }

        public async Task UnfollowAsync(string username, string accessToken)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target:username", username)
                .WithOptionalParameter("access_token", accessToken);

            await _requestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Unfollow, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusUser>> UpdateProfileAsync(string accessToken, string name = null, string about = null, string url = null, string location = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithOptionalParameter("name", name)
                .WithOptionalParameter("about", about)
                .WithOptionalParameter("url", url)
                .WithOptionalParameter("location", location);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.UpdateProfile, parameters)
                .ConfigureAwait(false);
        }
    }
}