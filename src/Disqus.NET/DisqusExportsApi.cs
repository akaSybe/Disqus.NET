using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusExportsApi : DisqusApiBase, IDisqusExportsApi
    {
        public DisqusExportsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<DisqusResponse<object>> ExportForumAsync(DisqusAccessToken accessToken, DisqusExportExportForumRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<object>>(DisqusRequestMethod.Post, DisqusEndpoints.Exports.ExportForum, parameters)
                .ConfigureAwait(false);
        }
    }
}