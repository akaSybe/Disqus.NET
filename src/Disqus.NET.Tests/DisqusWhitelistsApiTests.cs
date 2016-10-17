using System;
using System.Linq;
using System.Threading.Tasks;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusWhitelistsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task AddAsync_Test()
        {
            /* arrange */

            string testEmail = string.Format("{0}@test.test", Guid.NewGuid().ToString("N"));

            var request = DisqusWhitelistAddRequest
                .New(TestData.Forum)
                .Email(testEmail);

            /* act */

            var response = await Disqus.Whitelists.AddAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
            Assert.That(response.Response.First().Value, Is.EqualTo(testEmail));
        }

        [Test]
        public async Task RemoveAsync_Test()
        {
            /* arrange */

            string testEmail = "test@test.test";

            var addWhitelistEntryRequest = DisqusWhitelistAddRequest
                .New(TestData.Forum)
                .Email(testEmail);

            await Disqus.Whitelists.AddAsync(DisqusAccessToken.Create(TestData.AccessToken), addWhitelistEntryRequest).ConfigureAwait(false);

            /* act */

            var request = DisqusWhitelistRemoveRequest
                .New(TestData.Forum)
                .Email(testEmail);

            /* act */

            var response = await Disqus.Whitelists.RemoveAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
            Assert.That(response.Response.First().Value, Is.EqualTo(testEmail));
        }

        [Test]
        public async Task ListAsync_Test()
        {
            /* arrange */

            string testEmail = "test@test.test";

            var addWhitelistEntryRequest = DisqusWhitelistAddRequest
                .New(TestData.Forum)
                .Email(testEmail);

            await Disqus.Whitelists.AddAsync(DisqusAccessToken.Create(TestData.AccessToken), addWhitelistEntryRequest).ConfigureAwait(false);

            var request = DisqusWhitelistListRequest
                .New(TestData.Forum)
                .Related(DisqusWhitelistEntryRelated.Forum);

            /* act */

            var response = await Disqus.Whitelists.ListAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* teardown */

            var removeWhitelistEntryRequest = DisqusWhitelistRemoveRequest
                .New(TestData.Forum)
                .Email(testEmail);

            await Disqus.Whitelists.RemoveAsync(DisqusAccessToken.Create(TestData.AccessToken), removeWhitelistEntryRequest).ConfigureAwait(false);
        }
    }
}
