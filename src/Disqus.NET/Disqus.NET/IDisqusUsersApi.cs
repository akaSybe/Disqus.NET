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
        /// Returns details of a user.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/users/details/</remarks>
        /// <param name="userId">Looks up a user by ID</param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusUser>> GetDetailsAsync(int userId);

        /// <summary>
        /// Returns details of a user
        /// </summary>
        /// <param name="username"></param>
        /// <remarks>https://disqus.com/api/docs/users/details/</remarks>
        /// <returns></returns>
        Task<DisqusResponse<DisqusUser>> GetDetailsAsync(string username);
    }
}
