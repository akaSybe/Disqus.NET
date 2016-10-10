using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    /// <summary>
    /// User-specific methods
    /// <remarks>https://disqus.com/api/docs/users/</remarks>
    /// </summary>
    public interface IDisqusUsersApi
    {
        /// <summary>
        /// Lookup user by ID
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/details/</remarks>
        /// <param name="userId">Looks up a user by ID</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusUser>> DetailsAsync(int userId, string accessToken = null);

        /// <summary>
        /// Lookup user by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/details/</remarks>
        /// <returns></returns>
        Task<DisqusResponse<DisqusUser>> DetailsAsync(string username, string accessToken = null);

        /// <summary>
        /// Follow a user by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/follow/</remarks>
        /// <returns></returns>
        Task FollowAsync(string accessToken, int userId);

        /// <summary>
        /// Follow a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/follow/</remarks>
        /// <returns></returns>
        Task FollowAsync(string accessToken, string username);

        /// <summary>
        /// Returns a list of users a user is being followed by.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <param name="attach"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusUserListFollowersAttach attach = DisqusUserListFollowersAttach.None, string accessToken = null);

        /// <summary>
        /// Returns a list of users a user is being followed by.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <param name="attach"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusUserListFollowersAttach attach = DisqusUserListFollowersAttach.None, string accessToken = null);

        /// <summary>
        /// Returns a list of users a user is following.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <param name="attach"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowingAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusUserListFollowingAttach attach = DisqusUserListFollowingAttach.None, string accessToken = null);

        /// <summary>
        /// Returns a list of users a user is following.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <param name="attach"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowingAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusUserListFollowingAttach attach = DisqusUserListFollowingAttach.None, string accessToken = null);

        Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(string accessToken, string userName);

        Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(string accessToken, int userId);

        // TODO: required information about return type
        Task<DisqusResponse<string>> ReportAsync(string accessToken, int userId, DisqusUserReportReason reason);

        // TODO: required information about return type
        Task<DisqusResponse<string>> ReportAsync(string accessToken, string userName, DisqusUserReportReason reason);

        /// <summary>
        /// Unfollow a user by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/unfollow/</remarks>
        /// <returns></returns>
        Task UnfollowAsync(string accessToken, int userId);

        /// <summary>
        /// Unfollow a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/follow/</remarks>
        /// <returns></returns>
        Task UnfollowAsync(string accessToken, string username);

        /// <summary>
        /// Update user profile
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="name">Minimum length of 2;  Maximum length of 30</param>
        /// <param name="about"></param>
        /// <param name="url">URL (defined by RFC 3986); Maximum length of 200</param>
        /// <param name="location">Maximum length of 255</param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusUser>> UpdateProfileAsync(string accessToken, string name = null, string about = null, string url = null, string location = null);
    }
}
