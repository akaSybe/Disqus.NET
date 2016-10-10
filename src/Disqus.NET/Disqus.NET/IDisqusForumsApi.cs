using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

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
        /// Returns forum details.
        /// <remarks>https://disqus.com/api/docs/forums/details/</remarks>
        /// </summary>
        /// <param name="forum">Looks up a forum by ID (aka short name)</param>
        /// <param name="attach"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForum>> DetailsAsync(string forum, DisqusForumAttach attach = DisqusForumAttach.None, DisqusForumRelated related = DisqusForumRelated.None);


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
        /// Follow a forum.
        /// </summary>
        Task<DisqusResponse<IEnumerable<string>>> FollowAsync(string accessToken, string target);

        /// <summary>
        /// Unfollow a forum.
        /// </summary>
        Task<DisqusResponse<IEnumerable<string>>> UnfollowAsync(string accessToken, string target);
    }
}