using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusPostsApi
    {
        /// <summary>
        /// Returns information about a post.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/details/</remarks>
        /// <param name="postId"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> GetPostDetailsAsync(string postId, DisqusPostRelated related = DisqusPostRelated.None);
    }
}