using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusWhitelistsApi : DisqusApiBase, IDisqusWhitelistsApi
    {
        public DisqusWhitelistsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<DisqusResponse<IEnumerable<DisqusWhitelistEntry>>> AddAsync(DisqusAccessToken accessToken, DisqusWhitelistAddRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusWhitelistEntry>>>(DisqusRequestMethod.Post, DisqusEndpoints.Whitelists.Add, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusWhitelistEntry>>> ListAsync(DisqusAccessToken accessToken, DisqusWhitelistListRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusWhitelistEntry>>>(DisqusRequestMethod.Get, DisqusEndpoints.Whitelists.List, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusWhitelistEntry>>> RemoveAsync(DisqusAccessToken accessToken, DisqusWhitelistRemoveRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusWhitelistEntry>>>(DisqusRequestMethod.Post, DisqusEndpoints.Whitelists.Remove, parameters)
                .ConfigureAwait(false);
        }
    }
}