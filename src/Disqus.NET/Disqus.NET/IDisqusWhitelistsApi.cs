using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusWhitelistsApi
    {
        /// <summary>
        /// Adds an entry to the whitelist.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/whitelists/add/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusWhitelistEntry>>> AddAsync(DisqusAccessToken accessToken, DisqusWhitelistAddRequest request);

        /// <summary>
        /// Returns a list of all whitelist entries.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/whitelists/list/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusWhitelistEntry>>> ListAsync(DisqusAccessToken accessToken, DisqusWhitelistListRequest request);

        /// <summary>
        /// Removes an entry from the whitelist.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/whitelists/remove/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusWhitelistEntry>>> RemoveAsync(DisqusAccessToken accessToken, DisqusWhitelistRemoveRequest request);
    }
}
