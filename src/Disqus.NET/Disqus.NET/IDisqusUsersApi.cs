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
        Task<DisqusResponse<DisqusUser>> GetDetailsAsync(int userId, string accessToken = null);

        /// <summary>
        /// Lookup user by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/details/</remarks>
        /// <returns></returns>
        Task<DisqusResponse<DisqusUser>> GetDetailsAsync(string username, string accessToken = null);

        /// <summary>
        /// Follow a user by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/follow/</remarks>
        /// <returns></returns>
        Task FollowAsync(int userId, string accessToken);

        /// <summary>
        /// Follow a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/follow/</remarks>
        /// <returns></returns>
        Task FollowAsync(string username, string accessToken);

        /// <summary>
        /// Unfollow a user by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/unfollow/</remarks>
        /// <returns></returns>
        Task UnfollowAsync(int userId, string accessToken);

        /// <summary>
        /// Unfollow a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <remarks>https://disqus.com/api/docs/users/follow/</remarks>
        /// <returns></returns>
        Task UnfollowAsync(string username, string accessToken);
    }
}
