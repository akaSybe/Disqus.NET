using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusTrustedDomainsApi : DisqusApiBase, IDisqusTrustedDomainsApi
    {
        public DisqusTrustedDomainsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        /// <summary>
        /// Returns a list of forum trusted domains
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <returns></returns>
        public async Task<DisqusResponse<IEnumerable<DisqusTrustedDomain>>> ListAsync(DisqusAccessToken accessToken, string forum)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusTrustedDomain>>>(DisqusRequestMethod.Get, DisqusEndpoints.TrustedDomain.List, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a trusted domain to a forum
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="forum"></param>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public async Task<DisqusResponse<DisqusTrustedDomain>> CreateAsync(DisqusAccessToken accessToken, string forum, string domainName)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("forum", forum)
                .WithParameter("domainName", domainName);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusTrustedDomain>>(DisqusRequestMethod.Post, DisqusEndpoints.TrustedDomain.Create, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Removes a trusted domain from a forum
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<DisqusResponse<string>> KillAsync(DisqusAccessToken accessToken, int domain)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithParameter("domain", domain);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.TrustedDomain.Kill, parameters)
                .ConfigureAwait(false);
        }
    }
}