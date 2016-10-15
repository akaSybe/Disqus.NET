using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusApplicationsApi
    {
        Task<DisqusResponse<IEnumerable<DisqusApplicationUsage>>> ListUsageAsync(DisqusAccessToken accessToken, DisqusApplicationListUsageRequest request);
    }

    public class DisqusApplicationsApi : DisqusApiBase, IDisqusApplicationsApi
    {
        public DisqusApplicationsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<DisqusResponse<IEnumerable<DisqusApplicationUsage>>> ListUsageAsync(DisqusAccessToken accessToken, DisqusApplicationListUsageRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            var response = await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<string[]>>>(DisqusRequestMethod.Get, DisqusEndpoints.Applications.ListUsage, parameters)
                .ConfigureAwait(false);

            List<DisqusApplicationUsage> usages = new List<DisqusApplicationUsage>();

            foreach (var item in response.Response)
            {
                DisqusApplicationUsage usage = new DisqusApplicationUsage
                {
                    Date = DateTime.Parse(item[0]),
                    Usage = int.Parse(item[1])
                };

                usages.Add(usage);
            }

            return new DisqusResponse<IEnumerable<DisqusApplicationUsage>>
            {
                Code = response.Code,
                Response = usages
            };
        }
    }
}
