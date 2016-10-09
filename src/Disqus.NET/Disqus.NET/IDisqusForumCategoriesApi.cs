using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusForumCategoriesApi
    {
        Task<IDisqusResponse<IEnumerable<DisqusForumCategory>>> GetForumCategoryListAsync();

        Task<IDisqusResponse<DisqusForumCategory>> GetForumCategoryDetailsAsync(int id);
    }
}
