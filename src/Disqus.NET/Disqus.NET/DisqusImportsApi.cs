using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusImportsApi : DisqusApiBase, IDisqusImportsApi
    {
        public DisqusImportsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<DisqusResponse<DisqusImport>> DetailsAsync(DisqusAccessToken accessToken, string forum, string @group)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithParameter("group", group)
                .WithParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusImport>>(DisqusRequestMethod.Get, DisqusEndpoints.Imports.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusImport>>> ListAsync(DisqusAccessToken accessToken, string forum, string cursor = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("forum", forum)
                .WithOptionalParameter("cursor", cursor)
                .WithParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusImport>>>(DisqusRequestMethod.Get, DisqusEndpoints.Imports.List, parameters)
                .ConfigureAwait(false);
        }
    }
}