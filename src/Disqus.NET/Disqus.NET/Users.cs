using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Disqus.NET
{
    public class Users: IDisqusUsersApi
    {
        private readonly IDisqusRequestProcessor _disqusRequestProcessor;

        private string ApiSecretKey = "xx9HYM0hGC8ZvYRFq2XJDFIPTSCipCOghISXnfJ4OB1JbBOFHmbXlpQvoFcchftx";

        private readonly RestClient _restClient;
        private const string ApiBaserUrl = "https://disqus.com/api/3.0/";
        private const string ApiUrlSegment = "users";

        private const string UrlPostfix = ".json";

        private class Endpoints
        {
            public const string Details = "details" + UrlPostfix;
        }

        public Users(IDisqusRequestProcessor disqusRequestProcessor)
        {
            _disqusRequestProcessor = disqusRequestProcessor;
            Uri baseUri = new Uri(ApiBaserUrl);
            
            _restClient = new RestClient(new Uri(baseUri, ApiUrlSegment));
        }

        public async Task<DisqusResponse<DisqusUser>> GetDetailsAsync(int userId)
        {
            var request = new RestRequest(Endpoints.Details);
            request.Method = Method.GET;
            request.AddQueryParameter("user", userId.ToString());
            request.AddQueryParameter("api_secret", ApiSecretKey);

            IRestResponse response = await _restClient.ExecuteTaskAsync(request).ConfigureAwait(false);

            JObject jObject = JObject.Parse(response.Content);
            JToken code = jObject["code"];

            DisqusApiResponseCode responseCode = JsonConvert.DeserializeObject<DisqusApiResponseCode>(code.ToString());

            if (responseCode != DisqusApiResponseCode.Success)
            {
                JToken error = jObject["response"];
                string errorMessage = error.ToString();

                return new DisqusResponse<DisqusUser>
                {
                    Code = responseCode,
                    Response = null
                };
            }

            DisqusResponse<DisqusUser> result = JsonConvert.DeserializeObject<DisqusResponse<DisqusUser>>(response.Content);

            return result;
        }

        public async Task<DisqusResponse<DisqusUser>> GetDetailsAsync(string username)
        {
            var httpClient = new HttpClient();

            var content = await httpClient.GetAsync(ApiBaserUrl + Endpoints.Details).ConfigureAwait(false);
            content.EnsureSuccessStatusCode();
            var responseMessage = new HttpResponseMessage();
            
            string response = await content.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            if (content.StatusCode != HttpStatusCode.OK)
            {
                JObject jObject = JObject.Parse(response);
                JToken code = jObject["code"];

                DisqusApiResponseCode responseCode = JsonConvert.DeserializeObject<DisqusApiResponseCode>(code.ToString());

                JToken error = jObject["response"];
                string errorMessage = error.ToString();

                return new DisqusResponse<DisqusUser>
                {
                    Code = responseCode,
                    Response = null
                };
            }

            DisqusResponse<DisqusUser> result = JsonConvert.DeserializeObject<DisqusResponse<DisqusUser>>(response);

            return result;
        }
    }
}
