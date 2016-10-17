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

        public async Task<DisqusResponse<DisqusForum>> DetailsAsync(DisqusAccessToken accessToken, DisqusForumDetailsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForum>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForum>> DetailsAsync(DisqusForumDetailsRequest request)
        {
            return await DetailsAsync(null, request).ConfigureAwait(false);
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

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusCategory>>> ListCategoriesAsync(DisqusAccessToken accessToken, DisqusForumListCategoriesRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusCategory>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListCategories, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusCategory>>> ListCategoriesAsync(DisqusForumListCategoriesRequest request)
        {
            return await ListCategoriesAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(DisqusAccessToken accessToken, DisqusForumListFollowersRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListFollowers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(DisqusForumListFollowersRequest request)
        {
            return await ListFollowersAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusForumModerator>>> ListModeratorsAsync(DisqusAccessToken accessToken, string forum)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithParameter("forum", forum);

            return await RequestProcessor
               .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusForumModerator>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListModerators, parameters)
               .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusForumModerator>>> ListModeratorsAsync(string forum)
        {
            return await ListModeratorsAsync(null, forum).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostActiveUsersAsync(DisqusAccessToken accessToken, DisqusForumListMostActiveUsersRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListMostActiveUsers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostActiveUsersAsync(DisqusForumListMostActiveUsersRequest request)
        {
            return await ListMostActiveUsersAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostLikedUsersAsync(DisqusAccessToken accessToken, DisqusForumListMostLikedUsersRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListMostLikedUsers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostLikedUsersAsync(DisqusForumListMostLikedUsersRequest request)
        {
            return await ListMostLikedUsersAsync(null, request).ConfigureAwait(false);
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

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListUsersAsync(DisqusAccessToken accessToken, DisqusForumListUsersRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListUsers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListUsersAsync(DisqusForumListUsersRequest request)
        {
            return await ListUsersAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForumModerator>> AddModeratorAsync(DisqusAccessToken accessToken, DisqusForumAddModeratorRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForumModerator>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.AddModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(DisqusAccessToken accessToken, DisqusForumRemoveModeratorRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

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

        public async Task<DisqusResponse<IEnumerable<string>>> FollowAsync(DisqusAccessToken accessToken, string forum)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("target", forum);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> UnfollowAsync(DisqusAccessToken accessToken, string forum)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("target", forum);

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
