using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Disqus.NET
{
    public interface IDisqusRestClient
    {
        Task<HttpResponseMessage> ExecuteGetAsync(string endpoint, ICollection<KeyValuePair<string, string>> parameters);

        Task<HttpResponseMessage> ExecutePostAsync(string endpoint, ICollection<KeyValuePair<string, string>> parameters);
    }
}
