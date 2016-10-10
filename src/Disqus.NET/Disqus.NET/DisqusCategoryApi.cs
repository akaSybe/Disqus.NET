using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusCategoryApi : DisqusApiBase, IDisqusCategoryApi
    {
        public DisqusCategoryApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
            : base(requestProcessor, authMethod, key)
        {
            
        }

        public async Task<DisqusResponse<DisqusCategory>> CreateAsync(string accessToken, string forum, string title, bool @default = false)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("title", title)
                .WithParameter("default", @default ? 1 : 0);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusCategory>>(DisqusRequestMethod.Post, DisqusEndpoints.Categories.Create, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusCategory>> DetailsAsync(int categoryId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("category", categoryId);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusCategory>>(DisqusRequestMethod.Get, DisqusEndpoints.Categories.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<List<DisqusCategory>>> ListAsync(string forum, string sinceId = null, string cursor = null, int limit = 25, DisqusOrder order = DisqusOrder.Asc)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("limit", limit)
                .WithParameter("order", order.ToString().ToLower())
                .WithOptionalParameter("since_id", sinceId)
                .WithOptionalParameter("cursor", cursor);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<List<DisqusCategory>>>(DisqusRequestMethod.Get, DisqusEndpoints.Categories.List, parameters)
                .ConfigureAwait(false);
        }
    }
}