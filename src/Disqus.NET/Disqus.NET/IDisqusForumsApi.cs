using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    /// <summary>
    /// Forums-specific methods
    /// <remarks>https://disqus.com/api/docs/forums/</remarks>
    /// </summary>
    public interface IDisqusForumsApi
    {
        /// <summary>
        /// Adds a moderator to a forum.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <param name="userId"></param>
        /// <param name="canAdminister"></param>
        /// <param name="canEdit"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForumModerator>> AddModeratorAsync(string accessToken, string forum, int userId, bool? canAdminister = null, bool? canEdit = null);

        /// <summary>
        /// Creates a new forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/create/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForum>> CreateAsync(DisqusAccessToken accessToken, DisqusForumCreateRequest request);

        /// <summary>
        /// Returns forum details.
        /// <remarks>https://disqus.com/api/docs/forums/details/</remarks>
        /// </summary>
        /// <param name="forum">Looks up a forum by ID (aka short name)</param>
        /// <param name="attach"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForum>> DetailsAsync(string forum, DisqusForumAttach attach = DisqusForumAttach.None, DisqusForumRelated related = DisqusForumRelated.None);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/disableAds/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForum>> DisableAdsAsync(DisqusAccessToken accessToken, string forum);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/interestingForums/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingForum>>> InterestingForumsAsync(DisqusAccessToken accessToken, int limit);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/interestingForums/</remarks>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingForum>>> InterestingForumsAsync(int limit);

        /// <summary>
        /// Returns a list of categories within a forum.
        /// </summary>
        /// <param name="forum"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusCategory>>> ListCategoriesAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc);

        /// <summary>
        /// Returns a list of users following a forum.
        /// </summary>
        /// <param name="forum"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc);

        /// <summary>
        /// Returns a list of all moderators on a forum.
        /// </summary>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusForumModerator>>> ListModeratorsAsync(string forum);

        /// <summary>
        /// Returns a list of users active within a forum ordered by most comments made.
        /// </summary>
        /// <param name="forum"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostActiveUsersAsync(string forum, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Desc);

        /// <summary>
        /// Returns a list of users active within a forum ordered by most likes received.
        /// </summary>
        /// <param name="forum"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostLikedUsersAsync(string forum, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Desc);

        /// <summary>
        /// Returns a list of posts within a forum.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusForumListPostsRequest request);

        /// <summary>
        /// Returns a list of posts within a forum.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusForumListPostsRequest request);

        /// <summary>
        /// Returns a list of threads within a forum sorted by the date created.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListThreadsAsync(DisqusAccessToken accessToken, DisqusForumListThreadsRequest request);

        /// <summary>
        /// Returns a list of threads within a forum sorted by the date created.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListThreadsAsync(DisqusForumListThreadsRequest request);

        /// <summary>
        /// Returns a list of users active within a forum.
        /// </summary>
        /// <param name="forum"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListUsersAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc);

        /// <summary>
        /// Adds a moderator to a forum.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <param name="userName"></param>
        /// <param name="canAdminister"></param>
        /// <param name="canEdit"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForumModerator>> AddModeratorAsync(string accessToken, string forum, string userName, bool? canAdminister = null, bool? canEdit = null);

        /// <summary>
        /// Removes a moderator from a forum.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="moderatorId"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, int moderatorId);

        /// <summary>
        /// Removes a moderator from a forum.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, string forum, int userId);

        /// <summary>
        /// Removes a moderator from a forum.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(string accessToken, string forum, string userName);

        /// <summary>
        /// Switches a forum to use the regular default avatar instead of a custom one
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/removeDefaultAvatar/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> RemoveDefaultAvatarAsync(DisqusAccessToken accessToken, string forum);

        /// <summary>
        /// Follow a forum.
        /// </summary>
        Task<DisqusResponse<IEnumerable<string>>> FollowAsync(string accessToken, string target);

        /// <summary>
        /// Unfollow a forum.
        /// </summary>
        Task<DisqusResponse<IEnumerable<string>>> UnfollowAsync(string accessToken, string target);

        /// <summary>
        /// Updates forum details.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/update/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForum>> UpdateAsync(DisqusAccessToken accessToken, DisqusForumUpdateRequest request);

        /// <summary>
        /// Updates forum details.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/validate/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<string>>> ValidateAsync(DisqusAccessToken accessToken, DisqusForumValidateRequest request);
    }
}