using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disqus.NET
{
    public interface IDisqusRequestProcessor
    {
        Task<T> ExecuteAsync<T>(string endpoint, DisqusRequestMethod method, ICollection<KeyValuePair<string, string>> parameters);
    }
}
