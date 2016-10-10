using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusUsersApi : DisqusApiBase, IDisqusUsersApi
    {
        public DisqusUsersApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
            : base(requestProcessor, authMethod, key)
        {
            
        }
        
        public async Task<DisqusResponse<DisqusUser>> DetailsAsync(int userId, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user", userId.ToString())
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusUser>> DetailsAsync(string username, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user:username", username)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task FollowAsync(string accessToken, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target", userId.ToString())
                .WithOptionalParameter("access_token", accessToken);

            await RequestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task FollowAsync(string accessToken, string username)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target:username", username)
                .WithOptionalParameter("access_token", accessToken);

            await RequestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task UnfollowAsync(string accessToken, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target", userId.ToString())
                .WithOptionalParameter("access_token", accessToken);

            await RequestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Unfollow, parameters)
                .ConfigureAwait(false);
        }

        public async Task UnfollowAsync(string accessToken, string username)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target:username", username)
                .WithOptionalParameter("access_token", accessToken);

            await RequestProcessor
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

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.UpdateProfile, parameters)
                .ConfigureAwait(false);
        }
    }
}