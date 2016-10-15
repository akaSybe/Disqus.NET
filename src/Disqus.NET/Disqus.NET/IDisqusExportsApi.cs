using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusExportsApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/exports/exportForum/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<object>> ExportForumAsync(DisqusAccessToken accessToken, DisqusExportExportForumRequest request);
    }
}
