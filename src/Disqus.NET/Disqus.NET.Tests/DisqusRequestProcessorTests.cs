using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusTests
    {
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void ExecuteAsync_ThrowsDisqusApiException_IfRequestIsInvalid()
        {
            /* arrange */

            // simulate bad request to Disqus API

            string response = @"
                {
                    ""code"": 2,
                    ""response"": ""Invalid argument, 'user': Unable to find user '-1'""
                }
            ";

            HttpResponseMessage errorResponse = new HttpResponseMessage
            {
                Content = new StringContent(response),
                StatusCode = HttpStatusCode.BadRequest
            };

            var restClient = new Mock<IDisqusRestClient>();
            restClient
                .Setup(r => r.ExecuteGetAsync(It.IsAny<string>(), It.IsAny<ICollection<KeyValuePair<string, string>>>()))
                .ReturnsAsync(errorResponse);

            IDisqusRequestProcessor processor = new DisqusRequestProcessor(restClient.Object);

            /* act */

            ActualValueDelegate<Task<DisqusResponse<string>>> x = async () => await processor.ExecuteAsync<DisqusResponse<string>>("test", DisqusRequestMethod.GET, new List<KeyValuePair<string, string>>());
            Assert.That(x, Throws.TypeOf<DisqusApiException>());
        }

        [Test]
        public async Task ExecuteAsync_ReturnDisqusResponse_IfRequestIsValid()
        {
            /* arrange */

            // simulate success request to Disqus API

            string response = @"
                {
                    ""code"": 0,
                    ""response"": ""Payload""
                }
            ";

            HttpResponseMessage successResponse = new HttpResponseMessage
            {
                Content = new StringContent(response),
                StatusCode = HttpStatusCode.OK
            };

            var restClient = new Mock<IDisqusRestClient>();
            restClient
                .Setup(r => r.ExecuteGetAsync(It.IsAny<string>(), It.IsAny<ICollection<KeyValuePair<string, string>>>()))
                .ReturnsAsync(successResponse);

            IDisqusRequestProcessor processor = new DisqusRequestProcessor(restClient.Object);

            /* act */

            var result = await processor.ExecuteAsync<DisqusResponse<string>>("test", DisqusRequestMethod.GET, new List<KeyValuePair<string, string>>());

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.EqualTo("Payload"));
        }
    }
}
