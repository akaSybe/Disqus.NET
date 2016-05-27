using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    /// <summary>
    /// Forums-specific methods
    /// <remarks>https://disqus.com/api/docs/forums/</remarks>
    /// </summary>
    public interface IDisqusForumsApi
    {
        /// <summary>
        /// Returns forum details.
        /// <remarks>https://disqus.com/api/docs/forums/details/</remarks>
        /// </summary>
        /// <param name="forum">Looks up a forum by ID (aka short name)</param>
        /// <param name="attach"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusForum>> GetForumDetailsAsync(string forum, DisqusForumAttach attach = DisqusForumAttach.None, DisqusForumRelated related = DisqusForumRelated.None);
    }
}