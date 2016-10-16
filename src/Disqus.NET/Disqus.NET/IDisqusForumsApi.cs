using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    /// <summary>
    /// 
    /// <remarks>https://disqus.com/api/docs/forums/</remarks>
    /// </summary>
    public interface IDisqusForumsApi
    {
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
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForum>> DetailsAsync(DisqusAccessToken accessToken, DisqusForumDetailsRequest request);

        /// <summary>
        /// Returns forum details.
        /// <remarks>https://disqus.com/api/docs/forums/details/</remarks>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForum>> DetailsAsync(DisqusForumDetailsRequest request);

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
        Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusForum>>>> InterestingForumsAsync(DisqusAccessToken accessToken, int limit);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/interestingForums/</remarks>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusInterestingObject<DisqusForum>>>> InterestingForumsAsync(int limit);

        /// <summary>
        /// Returns a list of categories within a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listCategories/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusCategory>>> ListCategoriesAsync(DisqusAccessToken accessToken, DisqusForumListCategoriesRequest request);

        /// <summary>
        /// Returns a list of categories within a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listCategories/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusCategory>>> ListCategoriesAsync(DisqusForumListCategoriesRequest request);

        /// <summary>
        /// Returns a list of users following a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listFollowers/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(DisqusAccessToken accessToken, DisqusForumListFollowersRequest request);

        /// <summary>
        /// Returns a list of users following a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listFollowers/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListFollowersAsync(DisqusForumListFollowersRequest request);

        /// <summary>
        /// Returns a list of all moderators on a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listModerators/</remarks>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusForumModerator>>> ListModeratorsAsync(DisqusAccessToken accessToken, string forum);

        /// <summary>
        /// Returns a list of all moderators on a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listModerators/</remarks>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusForumModerator>>> ListModeratorsAsync(string forum);

        /// <summary>
        /// Returns a list of users active within a forum ordered by most comments made.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listMostActiveUsers/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostActiveUsersAsync(DisqusAccessToken accessToken, DisqusForumListMostActiveUsersRequest request);

        /// <summary>
        /// Returns a list of users active within a forum ordered by most comments made.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listMostActiveUsers/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostActiveUsersAsync(DisqusForumListMostActiveUsersRequest request);

        /// <summary>
        /// Returns a list of users active within a forum ordered by most likes received.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listMostLikedUsers/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostLikedUsersAsync(DisqusAccessToken accessToken, DisqusForumListMostLikedUsersRequest request);

        /// <summary>
        /// Returns a list of users active within a forum ordered by most likes received.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listMostLikedUsers/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListMostLikedUsersAsync(DisqusForumListMostLikedUsersRequest request);

        /// <summary>
        /// Returns a list of posts within a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listPosts/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusForumListPostsRequest request);

        /// <summary>
        /// Returns a list of posts within a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listPosts/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusForumListPostsRequest request);

        /// <summary>
        /// Returns a list of threads within a forum sorted by the date created.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listThreads/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListThreadsAsync(DisqusAccessToken accessToken, DisqusForumListThreadsRequest request);

        /// <summary>
        /// Returns a list of threads within a forum sorted by the date created.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listThreads/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListThreadsAsync(DisqusForumListThreadsRequest request);

        /// <summary>
        /// Returns a list of users active within a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listUsers/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListUsersAsync(DisqusAccessToken accessToken, DisqusForumListUsersRequest request);

        /// <summary>
        /// Returns a list of users active within a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/listUsers/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusUserBase>>> ListUsersAsync(DisqusForumListUsersRequest request);

        /// <summary>
        /// Adds a moderator to a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/addModerator/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForumModerator>> AddModeratorAsync(DisqusAccessToken accessToken, DisqusForumAddModeratorRequest request);

        /// <summary>
        /// Removes a moderator from a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/removeModerator/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusId>> RemoveModeratorAsync(DisqusAccessToken accessToken, DisqusForumRemoveModeratorRequest request);

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
        /// <remarks>https://disqus.com/api/docs/forums/follow/</remarks>
        Task<DisqusResponse<IEnumerable<string>>> FollowAsync(DisqusAccessToken accessToken, string forum);

        /// <summary>
        /// Unfollow a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/forums/unfollow/</remarks>
        Task<DisqusResponse<IEnumerable<string>>> UnfollowAsync(DisqusAccessToken accessToken, string forum);

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