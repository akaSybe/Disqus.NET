using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public interface IDisqusImportsApi
    {
        Task<DisqusResponse<DisqusImport>> DetailsAsync(DisqusAccessToken accessToken, string forum, string group);

        Task<CursoredDisqusResponse<IEnumerable<DisqusImport>>> ListAsync(DisqusAccessToken accessToken, string forum, string cursor = null);
    }
}
