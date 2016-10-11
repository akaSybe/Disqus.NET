using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusOrganizationsApi
    {
        /// <summary>
        /// List all the admins in an organization.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusAdmin>>> ListAdminsAsync(string accessToken, int organization);

        /// <summary>
        /// Adds an admin to an organization. Updates permissions of existing admins too.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organization">Looks up an organization by ID</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> AddAdminAsync(string accessToken, int organization, int userId);

        /// <summary>
        /// Adds an admin to an organization. Updates permissions of existing admins too.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organization">Looks up an organization by ID</param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> AddAdminAsync(string accessToken, int organization, string userName);

        /// <summary>
        /// Removes an admin from an organization.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organization"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> RemoveAdminAsync(string accessToken, int organization, int userId);

        /// <summary>
        /// Removes an admin from an organization.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organization"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> RemoveAdminAsync(string accessToken, int organization, string userName);

        /// <summary>
        /// Add a user with an arbitrary role to an organization.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organization"></param>
        /// <param name="userId"></param>
        /// <param name="isModerator"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> SetRoleAsync(string accessToken, int organization, int userId, bool? isModerator = null, bool? isAdmin = null);

        /// <summary>
        /// Add a user with an arbitrary role to an organization.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organization"></param>
        /// <param name="userName"></param>
        /// <param name="isModerator"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> SetRoleAsync(string accessToken, int organization, string userName, bool? isModerator = null, bool? isAdmin = null);
    }
}
