using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Disqus.NET
{
    public class DisqusRequestProcessor : IDisqusRequestProcessor
    {
        private readonly IDisqusRestClient _restClient;

        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public DisqusRequestProcessor(IDisqusRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<T> ExecuteAsync<T>(DisqusRequestMethod method, string endpoint, ICollection<KeyValuePair<string, string>> parameters)
        {
            HttpResponseMessage response = await ExecuteAsync(method, endpoint, parameters).ConfigureAwait(false);
            
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(content, SerializerSettings);
            }
            else
            {
                IDisqusResponse<string> errorResponse = JsonConvert.DeserializeObject<DisqusErrorResponse>(content, SerializerSettings);

                throw new DisqusApiException(errorResponse.Code, errorResponse.Response);
            }
        }

        private async Task<HttpResponseMessage> ExecuteAsync(DisqusRequestMethod method, string endpoint, ICollection<KeyValuePair<string, string>> parameters)
        {
            switch (method)
            {
                default:
                case DisqusRequestMethod.Get:
                    return await _restClient.ExecuteGetAsync(endpoint, parameters).ConfigureAwait(false);
                case DisqusRequestMethod.Post:
                    return await _restClient.ExecutePostAsync(endpoint, parameters).ConfigureAwait(false);
            }
        }
    }
}
