using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusTrendsApi : DisqusApiBase, IDisqusTrendsApi
    {
        public DisqusTrendsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<DisqusResponse<IEnumerable<DisqusTrend>>> ListThreadsAsync(DisqusAccessToken accessToken, DisqusTrendListThreadsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusTrend>>>(DisqusRequestMethod.Get, DisqusEndpoints.Trends.ListThreads, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusTrend>>> ListThreadsAsync(DisqusTrendListThreadsRequest request)
        {
            return await ListThreadsAsync(null, request).ConfigureAwait(false);
        }
    }
}