using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Extensions;
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

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusUserListFollowersAttach attach = DisqusUserListFollowersAttach.None, string accessToken = null)
        {
            DisqusParameters parameterBuilder = Parameters
                .WithParameter("user", userId)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("access_token", accessToken);

            if (attach != DisqusUserListFollowersAttach.None)
            {
                parameterBuilder.WithMultipleParameters("attach", attach.ToStringArray());
            }

            Collection<KeyValuePair<string, string>> parameters = parameterBuilder;

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusUserListFollowersAttach attach = DisqusUserListFollowersAttach.None, string accessToken = null)
        {
            DisqusParameters parameterBuilder = Parameters
                .WithParameter("user:username", userName)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("access_token", accessToken);

            if (attach != DisqusUserListFollowersAttach.None)
            {
                parameterBuilder.WithMultipleParameters("attach", attach.ToStringArray());
            }

            Collection<KeyValuePair<string, string>> parameters = parameterBuilder;

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowingAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusUserListFollowingAttach attach = DisqusUserListFollowingAttach.None, string accessToken = null)
        {
            DisqusParameters parameterBuilder = Parameters
                .WithParameter("user", userId)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("access_token", accessToken);

            if (attach != DisqusUserListFollowingAttach.None)
            {
                parameterBuilder.WithMultipleParameters("attach", attach.ToStringArray());
            }

            Collection<KeyValuePair<string, string>> parameters = parameterBuilder;

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowing, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowingAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusUserListFollowingAttach attach = DisqusUserListFollowingAttach.None, string accessToken = null)
        {
            DisqusParameters parameterBuilder = Parameters
                .WithParameter("user:username", userName)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("access_token", accessToken);

            if (attach != DisqusUserListFollowingAttach.None)
            {
                parameterBuilder.WithMultipleParameters("attach", attach.ToStringArray());
            }

            Collection<KeyValuePair<string, string>> parameters = parameterBuilder;

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowing, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(string accessToken, string userName)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("follower:username", userName);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.RemoveFollower, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(string accessToken, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("follower", userId);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.RemoveFollower, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> ReportAsync(string accessToken, int userId, DisqusUserReportReason reason)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("user", userId)
                .WithParameter("reason", (int)reason);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Report, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> ReportAsync(string accessToken, string userName, DisqusUserReportReason reason)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("user:username", userName)
                .WithParameter("reason", (int)reason);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Report, parameters)
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