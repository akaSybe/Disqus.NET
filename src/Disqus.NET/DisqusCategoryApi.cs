using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusCategoryApi : DisqusApiBase, IDisqusCategoryApi
    {
        public DisqusCategoryApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
            : base(requestProcessor, authMethod, key)
        {
            
        }

        public async Task<DisqusResponse<DisqusCategory>> CreateAsync(DisqusAccessToken accessToken, DisqusCategoryCreateRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusCategory>>(DisqusRequestMethod.Post, DisqusEndpoints.Categories.Create, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusCategory>> CreateAsync(DisqusCategoryCreateRequest request)
        {
            return await CreateAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusCategory>> DetailsAsync(DisqusAccessToken accessToken, int categoryId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithParameter("category", categoryId);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusCategory>>(DisqusRequestMethod.Get, DisqusEndpoints.Categories.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusCategory>> DetailsAsync(int categoryId)
        {
            return await DetailsAsync(null, categoryId).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<List<DisqusCategory>>> ListAsync(DisqusAccessToken accessToken, DisqusCategoryListRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<List<DisqusCategory>>>(DisqusRequestMethod.Get, DisqusEndpoints.Categories.List, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<List<DisqusCategory>>> ListAsync(DisqusCategoryListRequest request)
        {
            return await ListAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusCategoryListPostsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusPost>>>(DisqusRequestMethod.Get, DisqusEndpoints.Categories.ListPosts, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusCategoryListPostsRequest request)
        {
            return await ListPostsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListThreadsAsync(DisqusAccessToken accessToken, DisqusCategoryListThreadsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusThread>>>(DisqusRequestMethod.Get, DisqusEndpoints.Categories.ListThreads, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListThreadsAsync(DisqusCategoryListThreadsRequest request)
        {
            return await ListThreadsAsync(null, request).ConfigureAwait(false);
        }
    }
}