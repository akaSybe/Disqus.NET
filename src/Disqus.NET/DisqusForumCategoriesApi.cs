using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusForumCategoriesApi: DisqusApiBase, IDisqusForumCategoryApi
    {
        public DisqusForumCategoriesApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) 
            : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<IDisqusResponse<DisqusForumCategory>> DetailsAsync(int forumCategory)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forumCategory", forumCategory);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusForumCategory>>(DisqusRequestMethod.Get, DisqusEndpoints.ForumCategories.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<IDisqusResponse<IEnumerable<DisqusForumCategory>>> ListAsync()
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters;

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusForumCategory>>>(DisqusRequestMethod.Get, DisqusEndpoints.ForumCategories.List, parameters)
                .ConfigureAwait(false);
        }
    }
}
