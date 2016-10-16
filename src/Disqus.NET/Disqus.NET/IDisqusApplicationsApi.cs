using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusApplicationsApi
    {
        Task<DisqusResponse<IEnumerable<DisqusApplicationUsage>>> ListUsageAsync(DisqusAccessToken accessToken, DisqusApplicationListUsageRequest request);
    }
}
