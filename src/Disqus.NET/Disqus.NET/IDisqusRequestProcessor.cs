using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disqus.NET
{
    public interface IDisqusRequestProcessor
    {
        Task<T> ExecuteAsync<T>(DisqusRequestMethod method, string endpoint, ICollection<KeyValuePair<string, string>> parameters);
    }
}
