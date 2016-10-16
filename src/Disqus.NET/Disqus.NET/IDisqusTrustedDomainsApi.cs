using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusTrustedDomainsApi
    {
        Task<DisqusResponse<IEnumerable<DisqusTrustedDomain>>> ListAsync(DisqusAccessToken accessToken, string forum);

        Task<DisqusResponse<DisqusTrustedDomain>> CreateAsync(DisqusAccessToken accessToken, string forum, string domainName);

        Task<DisqusResponse<string>> KillAsync(DisqusAccessToken accessToken, int domainId);
    }
}
