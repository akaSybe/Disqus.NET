using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusOrganizationsApi
    {
        /// <summary>
        /// List all the admins in an organization.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/organizations/listAdmins/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusAdmin>>> ListAdminsAsync(DisqusAccessToken accessToken, int organization);

        /// <summary>
        /// Adds an admin to an organization. Updates permissions of existing admins too.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/organizations/addAdmin/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> AddAdminAsync(DisqusAccessToken accessToken, DisqusOrganizationAddAdminRequest request);

        /// <summary>
        /// Removes an admin from an organization.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/organizations/removeAdmin/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> RemoveAdminAsync(DisqusAccessToken accessToken, DisqusOrganizationRemoveAdminRequest request);

        /// <summary>
        /// Add a user with an arbitrary role to an organization.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/organizations/setRole/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusAdmin>> SetRoleAsync(DisqusAccessToken accessToken, DisqusOrganizationSetRoleRequest request);
    }
}
