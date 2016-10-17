using System;
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
        internal async Task<HttpResponseMessage> ExecuteRequestAsync(Func<HttpClient, Task<HttpResponseMessage>> httpClientAction)
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

                    return await httpClientAction(client).ConfigureAwait(false);
                }
            }
        }

        public async Task<HttpResponseMessage> ExecuteGetAsync(string endpoint, ICollection<KeyValuePair<string, string>> parameters)
        {
            string queryString = string.Join("&", parameters.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value)));
            string url = string.Format("{0}?{1}", endpoint, queryString);

            return await ExecuteRequestAsync(async client => await client.GetAsync(url).ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> ExecutePostAsync(string endpoint, ICollection<KeyValuePair<string, string>> parameters)
        {
            return await ExecuteRequestAsync(async client => await client.PostAsync(endpoint, new FormUrlEncodedContent(parameters)).ConfigureAwait(false))
                .ConfigureAwait(false);
        }
    }
}