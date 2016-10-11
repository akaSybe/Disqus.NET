using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusOrganizationsApi : DisqusApiBase, IDisqusOrganizationsApi
    {
        public DisqusOrganizationsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusAdmin>>> ListAdminsAsync(string accessToken, int organization)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("organization", organization);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusAdmin>>>(DisqusRequestMethod.Get, DisqusEndpoints.Organizations.ListAdmins, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> AddAdminAsync(string accessToken, int organization, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("organization", organization)
                .WithParameter("user", userId);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.AddAdmin, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> AddAdminAsync(string accessToken, int organization, string userName)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("organization", organization)
                .WithParameter("user:username", userName);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.AddAdmin, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> RemoveAdminAsync(string accessToken, int organization, int userId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("organization", organization)
                .WithParameter("user", userId);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.RemoveAdmin, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> RemoveAdminAsync(string accessToken, int organization, string userName)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("organization", organization)
                .WithParameter("user:username", userName);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.RemoveAdmin, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> SetRoleAsync(string accessToken, int organization, int userId, bool? isModerator = null, bool? isAdmin = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("organization", organization)
                .WithParameter("user", userId)
                .WithOptionalParameter("isModerator", isModerator.HasValue ? isModerator.Value ? 1 : 0 : (int?)null)
                .WithOptionalParameter("isAdmin", isAdmin.HasValue ? isAdmin.Value? 1 : 0 : (int?)null);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.SetRole, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusAdmin>> SetRoleAsync(string accessToken, int organization, string userName, bool? isModerator = null, bool? isAdmin = null)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("organization", organization)
                .WithParameter("user:username", userName)
                .WithOptionalParameter("isModerator", isModerator.HasValue ? isModerator.Value ? 1 : 0 : (int?)null)
                .WithOptionalParameter("isAdmin", isAdmin.HasValue ? isAdmin.Value ? 1 : 0 : (int?)null);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusAdmin>>(DisqusRequestMethod.Post, DisqusEndpoints.Organizations.SetRole, parameters)
                .ConfigureAwait(false);
        }
    }
}