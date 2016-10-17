using System.Linq;
using System.Threading.Tasks;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusApplicationApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task ListUsageAsync_Test()
        {
            /* arrange */

            int days = 20;

            var request = DisqusApplicationListUsageRequest
                .New()
                .Days(days)
                .Application(TestData.ApplicationId);

            /* act */

            var response = await Disqus.Applications.ListUsageAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
            Assert.That(response.Response.Count(), Is.EqualTo(days + 1));
        }
    }
}
