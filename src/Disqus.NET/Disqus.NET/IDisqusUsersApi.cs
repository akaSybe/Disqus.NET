using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    /// <summary>
    /// User-specific methods
    /// <remarks>https://disqus.com/api/docs/users/</remarks>
    /// </summary>
    public interface IDisqusUsersApi
    {
        /// <summary>
        /// Updates username for the user, fails if username does not meet requirements, or is taken by another user.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> CheckUsernameAsync(string accessToken, string username);

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
        /// Returns a list of interesting users. 
        /// This is not personalized to the user making the request. 
        /// The selection of users is pulled randomly from a list of ~100 interesting users
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/interestingUsers/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusUser>>>> InterestingUsersAsync(DisqusAccessToken accessToken, int limit);

        /// <summary>
        /// Returns a list of interesting users. 
        /// This is not personalized to the user making the request. 
        /// The selection of users is pulled randomly from a list of ~100 interesting users
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/interestingUsers/</remarks>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusUser>>>> InterestingUsersAsync(int limit);

        /// <summary>
        /// Returns a list of various activity types made by the user.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listActivity/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserActivity>>> ListActivityAsync(DisqusAccessToken accessToken, DisqusUserListActivityRequest request);

        /// <summary>
        /// Returns a list of various activity types made by the user.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listActivity/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserActivity>>> ListActivityAsync(DisqusUserListActivityRequest request);

        /// <summary>
        /// Returns a list of forums a user has been active on.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListActiveForumsAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc);

        /// <summary>
        /// Returns a list of forums a user has been active on.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListActiveForumsAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc);

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

        /// <summary>
        /// Returns a list of forums a user is following.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <param name="attach"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListFollowingForumsAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusForumAttach attach = DisqusForumAttach.None, string accessToken = null);

        /// <summary>
        /// Returns a list of forums a user is following.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <param name="attach"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListFollowingForumsAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, DisqusForumAttach attach = DisqusForumAttach.None, string accessToken = null);

        /// <summary>
        /// Returns a list of forums a user owns.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListForumsAsync(int userId, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, string accessToken = null);

        /// <summary>
        /// Returns a list of forums a user owns.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="sinceId"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListForumsAsync(string userName, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc, string accessToken = null);

        /// <summary>
        /// Returns a list of forums a user has been active on recenty, sorted by the user's activity.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusForum>>> ListMostActiveForumsAsync(int userId, int limit = 25, string accessToken = null);

        /// <summary>
        /// Returns a list of forums a user has been active on recenty, sorted by the user's activity.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="limit"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusForum>>> ListMostActiveForumsAsync(string userName, int limit = 25, string accessToken = null);

        /// <summary>
        /// Returns a list of posts made by the user.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listPosts/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusUsersListPostsRequest request);

        /// <summary>
        /// Returns a list of posts made by the user.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listPosts/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusUsersListPostsRequest request);

        /// <summary>
        /// Remove a user from set of followers.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(string accessToken, string userName);

        /// <summary>
        /// Remove a user from set of followers.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(string accessToken, int userId);

        // TODO: required information about return type
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> ReportAsync(string accessToken, int userId, DisqusUserReportReason reason);

        // TODO: required information about return type
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userName"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
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
