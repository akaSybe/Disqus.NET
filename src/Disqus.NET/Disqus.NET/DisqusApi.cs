using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    {
        private class DisqusParameters
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

        public async Task<DisqusResponse<DisqusUser>> GetUserDetailsAsync(int userId, string accessToken = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("user", userId.ToString())
                .WithOptionalParameter("access_token", accessToken);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusUser>>(DisqusRequestMethod.Get, DisqusEndpoints.Users.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusUser>> GetUserDetailsAsync(string username, string accessToken = null)
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

        public async Task<DisqusResponse<DisqusCategory>> CreateCategoryAsync(string accessToken, string forum, string title, bool @default = false)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("title", title)
                .WithParameter("default", @default ? 1 : 0);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusCategory>>(DisqusRequestMethod.Post, DisqusEndpoints.Categories.Create, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusCategory>> GetCategoryDetailsAsync(int categoryId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("category", categoryId);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusCategory>>(DisqusRequestMethod.Get, DisqusEndpoints.Categories.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<List<DisqusCategory>>> GetCategoryListAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("limit", limit)
                .WithParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor);

            return await _requestProcessor
                .ExecuteAsync<CursoredDisqusResponse<List<DisqusCategory>>>(DisqusRequestMethod.Get, DisqusEndpoints.Categories.List, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForum>> GetForumDetailsAsync(string forum, DisqusForumAttach attach = DisqusForumAttach.None, DisqusForumRelated related = DisqusForumRelated.None)
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

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForum>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusCategory>>> ListCategoriesAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("limit", limit)
                .WithParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor);

            return await _requestProcessor
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

            return await _requestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListFollowers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusForumModerator>>> ListModeratorsAsync(string forum)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum);

            return await _requestProcessor
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

            return await _requestProcessor
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

            return await _requestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListMostLikedUsers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListUsersAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("limit", limit)
                .WithParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor);

            return await _requestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>>(DisqusRequestMethod.Get, DisqusEndpoints.Forums.ListUsers, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForumModerator>> AddModeratorAsync(string accessToken, string forum, int userId, bool? canAdminister, bool? canEdit)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("user", userId)
                .WithOptionalParameter("canAdminister", canAdminister)
                .WithOptionalParameter("canEdit", canEdit);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForumModerator>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.AddModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusForumModerator>> AddModeratorAsync(string accessToken, string forum, string userName, bool? canAdminister, bool? canEdit)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("user:username", userName)
                .WithOptionalParameter("canAdminister", canAdminister)
                .WithOptionalParameter("canEdit", canEdit);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForumModerator>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.AddModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, int moderatorId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("moderator", moderatorId);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusId>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.RemoveModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, string forum, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("user", userId);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusId>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.RemoveModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, string forum, string userName)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("user:username", userName);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusId>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.RemoveModerator, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> FollowForumAsync(string accessToken, string target)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("target", target);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.Follow, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<string>>> UnfollowForumAsync(string accessToken, string target)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("target", target);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string>>>(DisqusRequestMethod.Post, DisqusEndpoints.Forums.Unfollow, parameters)
                .ConfigureAwait(false);
        }

        public async Task<IDisqusResponse<IEnumerable<DisqusForumCategory>>> GetForumCategoryListAsync()
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters;

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusForumCategory>>>(DisqusRequestMethod.Post, DisqusEndpoints.ForumCategories.List, parameters)
                .ConfigureAwait(false);
        }

        public async Task<IDisqusResponse<DisqusForumCategory>> GetForumCategoryDetailsAsync(int id)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forumCategory", id);

            return await _requestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForumCategory>>(DisqusRequestMethod.Get, DisqusEndpoints.ForumCategories.Details, parameters)
                .ConfigureAwait(false);
        }
    }
}