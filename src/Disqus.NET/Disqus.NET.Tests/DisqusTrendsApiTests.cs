using System.Linq;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusTrendsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task ListThreadsAsync_Test()
        {
            /* arrange */

            var request = DisqusTrendListThreadsRequest
                .New()
                .Related(DisqusThreadRelated.Author | DisqusThreadRelated.Forum | DisqusThreadRelated.Category);

            /* act */

            var response = await Disqus.Trends.ListThreadsAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }
    }
}
