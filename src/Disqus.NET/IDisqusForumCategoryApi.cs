using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusForumCategoryApi
    {
        Task<IDisqusResponse<DisqusForumCategory>> DetailsAsync(int forumCategory);

        Task<IDisqusResponse<IEnumerable<DisqusForumCategory>>> ListAsync();
    }
}
