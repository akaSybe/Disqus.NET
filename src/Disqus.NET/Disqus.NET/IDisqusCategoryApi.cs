using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusCategoryApi
    {
        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <param name="title"></param>
        /// <param name="default"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusCategory>> CreateAsync(string accessToken, string forum, string title, bool @default = false);

        /// <summary>
        /// Returns category details.
        /// </summary>
        /// <remarks>https://disqus.com/api/3.0/categories/details.json</remarks>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusCategory>> DetailsAsync(int categoryId);

        /// <summary>
        /// Returns a list of categories within a forum.
        /// </summary>
        /// <remarks>https://disqus.com/api/3.0/categories/list.json</remarks>
        /// <returns></returns>
        /// <param name="forum"></param>
        /// <param name="sinceId">category id</param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<List<DisqusCategory>>> ListAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc);
    }
}