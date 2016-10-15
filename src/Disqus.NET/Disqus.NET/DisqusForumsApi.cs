using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Extensions;
using Disqus.NET.Internal;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusForumsApi : DisqusApiBase, IDisqusForumsApi
    {
        public DisqusForumsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
            : base(requestProcessor, authMethod, key)
        {

        }

        public async Task<DisqusResponse<DisqusForum>> CreateAsync(DisqusAccessToken accessToken, DisqusForumCreateRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForum>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.Create, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForum>> DetailsAsync(string forum, DisqusForumAttach attach = DisqusForumAttach.None, DisqusForumRelated related = DisqusForumRelated.None)
        {
            DisqusParameters parameterBuilder = Parameters
                .WithParameter("forum", forum);

            if (related != DisqusForumRelated.None)
            {
                parameterBuilder.WithParameter("related", related.ToString().ToLower());
            }

            if (attach != DisqusForumAttach.None)
            {
                parameterBuilder.WithMultipleParameters("attach", attach.ToStringArray());
            }

            Collection<KeyValuePair<string, string>> parameters = parameterBuilder;

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForum>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForum>> DisableAdsAsync(DisqusAccessToken accessToken, string forum)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForum>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.DisableAds, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusForum>>>> InterestingForumsAsync(DisqusAccessToken accessToken, int limit)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("limit", limit)
                .WithOptionalParameter("access_token", accessToken);

            var response = await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<DisqusInterestingCollection<DisqusForum>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.InterestingForums, parameters)
                .ConfigureAwait(false);

            List<DisqusInterestingObject<DisqusForum>> forums = new List<DisqusInterestingObject<DisqusForum>>();

            foreach (var interestingForumItem in response.Response.Items)
            {
                DisqusForum forum;
                if (response.Response.Objects.TryGetValue(interestingForumItem.Id, out forum))
                {
                    forums.Add(new DisqusInterestingObject<DisqusForum>
                    {
                        Reason = interestingForumItem.Reason,
                        Object = forum
                    });
                }    
            }

            return new CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusForum>>>
            {
                Cursor = response.Cursor,
                Code = response.Code,
                Response = forums
            };
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusForum>>>> InterestingForumsAsync(int limit)
        {
            return await InterestingForumsAsync(null, limit).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusCategory>>> ListCategoriesAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
               .WithParameter("forum", forum)
               .WithParameter("limit", limit)
               .WithParameter("order", order.ToString().ToLower())
               .WithOptionalParameter("since_id", sinceId)
               .WithOptionalParameter("cursor", cursor);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusCategory>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListCategories, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("limit", limit)
                .WithParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListFollowers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusForumModerator>>> ListModeratorsAsync(string forum)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum);

            return await RequestProcessor
               .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForumModerator>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListModerators, parameters)
               .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostActiveUsersAsync(string forum, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Desc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("limit", limit)
                .WithParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("cursor", cursor);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListMostActiveUsers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostLikedUsersAsync(string forum, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Desc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("limit", limit)
                .WithParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("cursor", cursor);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListMostLikedUsers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusForumListPostsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusPost>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListPosts, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusForumListPostsRequest request)
        {
            return await ListPostsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListThreadsAsync(DisqusAccessToken accessToken, DisqusForumListThreadsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusThread>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListThreads, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListThreadsAsync(DisqusForumListThreadsRequest request)
        {
            return await ListThreadsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListUsersAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("limit", limit)
                .WithParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListUsers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForumModerator>> AddModeratorAsync(string accessToken, string forum, int userId, bool? canAdminister = null, bool? canEdit = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("user", userId)
                .WithOptionalParameter("canAdminister", canAdminister)
                .WithOptionalParameter("canEdit", canEdit);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForumModerator>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.AddModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForumModerator>> AddModeratorAsync(string accessToken, string forum, string userName, bool? canAdminister = null, bool? canEdit = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("user:username", userName)
                .WithOptionalParameter("canAdminister", canAdminister)
                .WithOptionalParameter("canEdit", canEdit);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForumModerator>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.AddModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, int moderatorId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("moderator", moderatorId);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusId>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.RemoveModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, string forum, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("user", userId);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusId>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.RemoveModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, string forum, string userName)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("user:username", userName);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusId>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.RemoveModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> RemoveDefaultAvatarAsync(DisqusAccessToken accessToken, string forum)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.RemoveDefaultAvatar, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> FollowAsync(string accessToken, string target)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("target", target);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> UnfollowAsync(string accessToken, string target)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("target", target);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.Unfollow, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForum>> UpdateAsync(DisqusAccessToken accessToken, DisqusForumUpdateRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForum>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.Update, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> ValidateAsync(DisqusAccessToken accessToken, DisqusForumValidateRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.Validate, parameters)
                .ConfigureAwait(false);
        }
    }
}
