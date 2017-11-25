using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Disqus.NET.Internal;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusUsersApi : DisqusApiBase, IDisqusUsersApi
    {
        public DisqusUsersApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
            : base(requestProcessor, authMethod, key)
        {
            
        }

        public async Task<DisqusResponse<string>> CheckUsernameAsync(DisqusAccessToken accessToken, string username)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("username", username);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.CheckUsername, parameters)
                .ConfigureAwait(false);
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

        public async Task FollowAsync(DisqusAccessToken accessToken, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target", userId.ToString())
                .WithOptionalParameter("access_token", accessToken);

            await RequestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task FollowAsync(DisqusAccessToken accessToken, string username)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target:username", username)
                .WithOptionalParameter("access_token", accessToken);

            await RequestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusUser>>>> InterestingUsersAsync(DisqusAccessToken accessToken, int limit)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("limit", limit)
                .WithOptionalParameter("access_token", accessToken);

            var response = await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<DisqusInterestingCollection<DisqusUser>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.InterestingUsers, parameters)
                .ConfigureAwait(false);

            List<DisqusInterestingObject<DisqusUser>> forums = new List<DisqusInterestingObject<DisqusUser>>();

            foreach (var interestingForumItem in response.Response.Items)
            {
                DisqusUser forum;
                if (response.Response.Objects.TryGetValue(interestingForumItem.Id, out forum))
                {
                    forums.Add(new DisqusInterestingObject<DisqusUser>
                    {
                        Reason = interestingForumItem.Reason,
                        Object = forum
                    });
                }
            }

            return new CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusUser>>>
            {
                Cursor = response.Cursor,
                Code = response.Code,
                Response = forums
            };
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusUser>>>> InterestingUsersAsync(int limit)
        {
            return await InterestingUsersAsync(null, limit).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserActivity>>> ListActivityAsync(DisqusAccessToken accessToken, DisqusUserListActivityRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserActivity>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListActivity, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserActivity>>> ListActivityAsync(DisqusUserListActivityRequest request)
        {
            return await ListActivityAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListActiveForumsAsync(DisqusAccessToken accessToken, DisqusUserListActiveForumsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListActiveForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListActiveForumsAsync(DisqusUserListActiveForumsRequest request)
        {
            return await ListActiveForumsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(DisqusAccessToken accessToken, DisqusUserListFollowersRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(DisqusUserListFollowersRequest request)
        {
            return await ListFollowersAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowingAsync(DisqusAccessToken accessToken, DisqusUserListFollowingRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowing, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowingAsync(DisqusUserListFollowingRequest request)
        {
            return await ListFollowingAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListFollowingForumsAsync(DisqusAccessToken accessToken, DisqusUserListFollowingForumsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowingForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListFollowingForumsAsync(DisqusUserListFollowingForumsRequest request)
        {
            return await ListFollowingForumsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListForumsAsync(DisqusAccessToken accessToken, DisqusUserListForumsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListForumsAsync(DisqusUserListForumsRequest request)
        {
            return await ListForumsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusForum>>> ListMostActiveForumsAsync(DisqusAccessToken accessToken, DisqusUserListMostActiveForumsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListMostActiveForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusForum>>> ListMostActiveForumsAsync(DisqusUserListMostActiveForumsRequest request)
        {
            return await ListMostActiveForumsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusUserListPostsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusPost>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListPosts, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusUserListPostsRequest request)
        {
            return await ListPostsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(DisqusAccessToken accessToken, string userName)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("follower:username", userName);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.RemoveFollower, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(DisqusAccessToken accessToken, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("follower", userId);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.RemoveFollower, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> ReportAsync(DisqusAccessToken accessToken, int userId, DisqusUserReportReason reason)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("user", userId)
                .WithParameter("reason", (int)reason);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Report, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> ReportAsync(DisqusAccessToken accessToken, string username, DisqusUserReportReason reason)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("user:username", username)
                .WithParameter("reason", (int)reason);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Report, parameters)
                .ConfigureAwait(false);
        }

        public async Task UnfollowAsync(DisqusAccessToken accessToken, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target", userId.ToString())
                .WithParameter("access_token", accessToken);

            await RequestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Unfollow, parameters)
                .ConfigureAwait(false);
        }

        public async Task UnfollowAsync(DisqusAccessToken accessToken, string username)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("target:username", username)
                .WithParameter("access_token", accessToken);

            await RequestProcessor
                .ExecuteAsync<DisqusResponse<List<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.Unfollow, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusUser>> UpdateProfileAsync(DisqusAccessToken accessToken, DisqusUserUpdateProfileRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Post, DisqusEndpoints.Users.UpdateProfile, parameters)
                .ConfigureAwait(false);
        }
    }
}