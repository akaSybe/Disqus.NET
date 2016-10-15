using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusBlacklistsApi : DisqusApiBase, IDisqusBlacklistsApi
    {
        public DisqusBlacklistsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<DisqusResponse<IEnumerable<DisqusBlacklistEntry>>> AddAsync(DisqusAccessToken accessToken, DisqusBlacklistAddRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusBlacklistEntry>>>(DisqusRequestMethod.Post, DisqusEndpoints.Blacklists.Add, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusBlacklistEntry>>> ListAsync(DisqusAccessToken accessToken, DisqusBlacklistListRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusBlacklistEntry>>>(DisqusRequestMethod.Get, DisqusEndpoints.Blacklists.List, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusBlacklistEntry>>> RemoveAsync(DisqusAccessToken accessToken, DisqusBlacklistRemoveRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusBlacklistEntry>>>(DisqusRequestMethod.Post, DisqusEndpoints.Blacklists.Remove, parameters)
                .ConfigureAwait(false);
        }
    }
}