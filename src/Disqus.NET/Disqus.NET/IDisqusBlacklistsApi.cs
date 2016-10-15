using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusBlacklistsApi
    {
        /// <summary>
        /// Adds an entry to the blacklist.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/blacklists/add/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusBlacklistEntry>>> AddAsync(DisqusAccessToken accessToken, DisqusBlacklistAddRequest request);

        /// <summary>
        /// Returns a list of all blacklist entries.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/blacklists/list/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusBlacklistEntry>>> ListAsync(DisqusAccessToken accessToken, DisqusBlacklistListRequest request);

        /// <summary>
        /// Removes an entry from the blacklist.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/blacklists/remove/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusBlacklistEntry>>> RemoveAsync(DisqusAccessToken accessToken, DisqusBlacklistRemoveRequest request);
    }
}
