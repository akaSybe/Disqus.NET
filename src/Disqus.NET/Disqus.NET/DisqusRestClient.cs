using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Disqus.NET
{
    public class DisqusRestClient : IDisqusRestClient
    {
        public async Task<HttpResponseMessage> ExecuteGetAsync(string endpoint, ICollection<KeyValuePair<string, string>> parameters)
        {
            string queryString = string.Join("&", parameters.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value)));
            string url = string.Format("{0}?{1}", endpoint, queryString);

            using (HttpClientHandler gzipHandler = new HttpClientHandler())
            {
                if (gzipHandler.SupportsAutomaticDecompression)
                {
                    gzipHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                }

                using (var client = new HttpClient(gzipHandler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return await client.GetAsync(url).ConfigureAwait(false);
                }
            }
        }

        public async Task<HttpResponseMessage> ExecutePostAsync(string endpoint, ICollection<KeyValuePair<string, string>> parameters)
        {
            using (HttpClientHandler gzipHandler = new HttpClientHandler())
            {
                if (gzipHandler.SupportsAutomaticDecompression)
                {
                    gzipHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                }

                using (var client = new HttpClient(gzipHandler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return await client.PostAsync(endpoint, new FormUrlEncodedContent(parameters)).ConfigureAwait(false);
                }
            }
        }
    }
}