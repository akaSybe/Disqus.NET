using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disqus.NET
{
    /// <summary>
    /// Hide details of implementation of making HTTP requests, error handling & deserialization of response 
    /// </summary>
    public interface IDisqusRequestProcessor
    {
        Task<T> ExecuteAsync<T>(DisqusRequestMethod method, string endpoint, ICollection<KeyValuePair<string, string>> parameters);
    }
}
