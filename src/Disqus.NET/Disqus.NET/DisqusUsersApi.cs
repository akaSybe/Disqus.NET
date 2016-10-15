using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Extensions;
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

        public async Task<DisqusResponse<string>> CheckUsernameAsync(string accessToken, string username)
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

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListActiveForumsAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user", userId)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower());

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListActiveForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListActiveForumsAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user:username", userName)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower());

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListActiveForums, parameters)
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

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListFollowingForumsAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusForumAttach attach = DisqusForumAttach.None, string accessToken = null)
        {
            DisqusParameters parameterBuilder = Parameters
                .WithParameter("user", userId)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("access_token", accessToken);

            if (attach != DisqusForumAttach.None)
            {
                parameterBuilder.WithMultipleParameters("attach", attach.ToStringArray());
            }

            Collection<KeyValuePair<string, string>> parameters = parameterBuilder;

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowingForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListFollowingForumsAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusForumAttach attach = DisqusForumAttach.None, string accessToken = null)
        {
            DisqusParameters parameterBuilder = Parameters
                .WithParameter("user:username", userName)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("access_token", accessToken);

            if (attach != DisqusForumAttach.None)
            {
                parameterBuilder.WithMultipleParameters("attach", attach.ToStringArray());
            }

            Collection<KeyValuePair<string, string>> parameters = parameterBuilder;

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListFollowingForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListForumsAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user", userId)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListForumsAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user:username", userName)
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor)
                .WithOptionalParameter("limit", limit)
                .WithOptionalParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusForum>>> ListMostActiveForumsAsync(int userId, int limit = 25, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user", userId)
                .WithParameter("limit", limit)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListMostActiveForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusForum>>> ListMostActiveForumsAsync(string userName, int limit = 25, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user:username", userName)
                .WithParameter("limit", limit)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListMostActiveForums, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusUsersListPostsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusPost>>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.ListPosts, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusUsersListPostsRequest request)
        {
            return await ListPostsAsync(null, request).ConfigureAwait(false);
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