using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IUsers
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
        /// <returns></returns>
        Task<DisqusResponse<DisqusUser>> GetDetailsAsync(string username);
    }
}
