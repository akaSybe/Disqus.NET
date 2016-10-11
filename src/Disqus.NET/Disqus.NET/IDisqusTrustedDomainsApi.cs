using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusTrustedDomainsApi
    {
        Task<DisqusResponse<IEnumerable<DisqusTrustedDomain>>> ListAsync(string accessToken, string forum);

        Task<DisqusResponse<DisqusTrustedDomain>> CreateAsync(string accessToken, string forum, string domainName);

        Task<DisqusResponse<string>> KillAsync(string accessToken, int domain);
    }
}
