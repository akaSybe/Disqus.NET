using System;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Disqus.NET
{
    public class Users: IUsers
    {
        private string ApiSecretKey = "xx9HYM0hGC8ZvYRFq2XJDFIPTSCipCOghISXnfJ4OB1JbBOFHmbXlpQvoFcchftx";

        private readonly RestClient _restClient;
        private const string ApiBaserUrl = "https://disqus.com/api/3.0/";
        private const string ApiUrlSegment = "users";

        private const string UrlPostfix = ".json";

        private class Endpoints
        {
            public const string Details = "details" + UrlPostfix;
        }

        public Users()
        {
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

            DisqusErrorCode responseCode = JsonConvert.DeserializeObject<DisqusErrorCode>(code.ToString());

            if (responseCode != DisqusErrorCode.Success)
            {
                JToken error = jObject["response"];
                string errorMessage = error.ToString();

                return new DisqusResponse<DisqusUser>
                {
                    Code = responseCode,
                    Error = errorMessage,
                    Response = null
                };
            }

            DisqusResponse<DisqusUser> result = JsonConvert.DeserializeObject<DisqusResponse<DisqusUser>>(response.Content);

            return result;
        }

        public Task<DisqusResponse<DisqusUser>> GetDetailsAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
