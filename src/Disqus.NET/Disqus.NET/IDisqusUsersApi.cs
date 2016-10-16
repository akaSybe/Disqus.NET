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
        /// <remarks>https://disqus.com/api/docs/users/checkUsername/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> CheckUsernameAsync(DisqusAccessToken accessToken, string username);

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
        Task FollowAsync(DisqusAccessToken accessToken, int userId);

        /// <summary>
        /// Follow a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/follow/</remarks>
        /// <returns></returns>
        Task FollowAsync(DisqusAccessToken accessToken, string username);

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
        /// <remarks>https://disqus.com/api/docs/users/listActiveForums/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListActiveForumsAsync(DisqusAccessToken accessToken, DisqusUserListActiveForumsRequest request);

        /// <summary>
        /// Returns a list of forums a user has been active on.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listActiveForums/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListActiveForumsAsync(DisqusUserListActiveForumsRequest request);

        /// <summary>
        /// Returns a list of users a user is being followed by.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listFollowers/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(DisqusAccessToken accessToken, DisqusUserListFollowersRequest request);

        /// <summary>
        /// Returns a list of users a user is being followed by.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listFollowers/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(DisqusUserListFollowersRequest request);

        /// <summary>
        /// Returns a list of users a user is following.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listFollowing/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowingAsync(DisqusAccessToken accessToken, DisqusUserListFollowingRequest request);

        /// <summary>
        /// Returns a list of users a user is following.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listFollowing/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowingAsync(DisqusUserListFollowingRequest request);

        /// <summary>
        /// Returns a list of forums a user is following.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listFollowingForums/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListFollowingForumsAsync(DisqusAccessToken accessToken, DisqusUserListFollowingForumsRequest request);

        /// <summary>
        /// Returns a list of forums a user is following.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listFollowingForums/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListFollowingForumsAsync(DisqusUserListFollowingForumsRequest request);

        /// <summary>
        /// Returns a list of forums a user owns.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listForums/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListForumsAsync(DisqusAccessToken accessToken, DisqusUserListForumsRequest request);

        /// <summary>
        /// Returns a list of forums a user owns.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listForums/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusForum>>> ListForumsAsync(DisqusUserListForumsRequest request);

        /// <summary>
        /// Returns a list of forums a user has been active on recenty, sorted by the user's activity.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listMostActiveForums/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusForum>>> ListMostActiveForumsAsync(DisqusAccessToken accessToken, DisqusUserListMostActiveForumsRequest request);

        /// <summary>
        /// Returns a list of forums a user has been active on recenty, sorted by the user's activity.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listMostActiveForums/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusForum>>> ListMostActiveForumsAsync(DisqusUserListMostActiveForumsRequest request);

        /// <summary>
        /// Returns a list of posts made by the user.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listPosts/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusUserListPostsRequest request);

        /// <summary>
        /// Returns a list of posts made by the user.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/listPosts/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusUserListPostsRequest request);

        /// <summary>
        /// Remove a user from set of followers.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/removeFollower/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(DisqusAccessToken accessToken, string userName);

        /// <summary>
        /// Remove a user from set of followers.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/removeFollower/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<string>>> RemoveFollowerAsync(DisqusAccessToken accessToken, int userId);

        // TODO: required information about return type
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/report/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> ReportAsync(DisqusAccessToken accessToken, int userId, DisqusUserReportReason reason);

        // TODO: required information about return type
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/report/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="userName"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> ReportAsync(DisqusAccessToken accessToken, string userName, DisqusUserReportReason reason);

        /// <summary>
        /// Unfollow a user by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/unfollow/</remarks>
        /// <returns></returns>
        Task UnfollowAsync(DisqusAccessToken accessToken, int userId);

        /// <summary>
        /// Unfollow a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/follow/</remarks>
        /// <returns></returns>
        Task UnfollowAsync(DisqusAccessToken accessToken, string username);

        /// <summary>
        /// Update user profile
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/updateProfile/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusUser>> UpdateProfileAsync(DisqusAccessToken accessToken, DisqusUserUpdateProfileRequest request);
    }
}
