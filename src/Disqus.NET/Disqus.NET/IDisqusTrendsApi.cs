using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusTrendsApi
    {
        /// <summary>
        /// Returns a list of trending threads.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/trends/listThreads/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusTrend>>> ListThreadsAsync(DisqusAccessToken accessToken, DisqusTrendListThreadsRequest request);

        /// <summary>
        /// Returns a list of trending threads.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/trends/listThreads/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusTrend>>> ListThreadsAsync(DisqusTrendListThreadsRequest request);
    }
}
