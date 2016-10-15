using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusPostsApi
    {
        /// <summary>
        /// Approves the requested post(s).
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> ApproveAsync(string accessToken, params string[] post);

        /// <summary>
        /// Returns information about a post.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> DetailsAsync(string postId, DisqusPostRelated related);

        /// <summary>
        /// Returns information about a post.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="postId"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> DetailsAsync(DisqusAccessToken accessToken, string postId, DisqusPostRelated related);
    }
}
