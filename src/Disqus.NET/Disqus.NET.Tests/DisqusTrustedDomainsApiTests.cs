using System.Threading.Tasks;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusTrustedDomainsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task CreateAsync_Test()
        {
            var response = await Disqus.TrustedDomains.CreateAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.Forum, TestData.TrustedDomain).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Domain, Is.EqualTo(TestData.TrustedDomain));
        }

        [Test]
        public async Task KillAsync_Test()
        {
            /* arrange */

            var result = await Disqus.TrustedDomains.CreateAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.Forum, TestData.TrustedDomain).ConfigureAwait(false);

            /* act */

            var response = await Disqus.TrustedDomains.KillAsync(DisqusAccessToken.Create(TestData.AccessToken), result.Response.Id).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        }

        [Test]
        public async Task ListAsync_Test()
        {
            /* arrange */

            await Disqus.TrustedDomains.CreateAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.Forum, TestData.TrustedDomain).ConfigureAwait(false);

            /* act */ 

            var response = await Disqus.TrustedDomains.ListAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.Forum).ConfigureAwait(false);

            /* assert */
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }
    }
}
