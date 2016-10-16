using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusOrganizationsApi : DisqusApiBase, IDisqusOrganizationsApi
    {
        public DisqusOrganizationsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusAdmin>>> ListAdminsAsync(DisqusAccessToken accessToken, int organization)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("organization", organization);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusAdmin>>>(DisqusRequestMethod.Get, DisqusEndpoints.Organizations.ListAdmins, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> AddAdminAsync(DisqusAccessToken accessToken, DisqusOrganizationAddAdminRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.AddAdmin, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> RemoveAdminAsync(DisqusAccessToken accessToken, DisqusOrganizationRemoveAdminRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.RemoveAdmin, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> SetRoleAsync(DisqusAccessToken accessToken, DisqusOrganizationSetRoleRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.SetRole, parameters)
                .ConfigureAwait(false);
        }
    }
}