using System;
using System.Linq;
using System.Threading.Tasks;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusBlacklistsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task AddAsync_Test()
        {
            /* arrange */

            string testEmail = string.Format("{0}@test.test", Guid.NewGuid().ToString("N"));

            var request = DisqusBlacklistAddRequest
                .New(TestData.Forum)
                .Email(testEmail);

            /* act */

            var response = await Disqus.Blacklists.AddAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

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

            var addBlacklistEntryRequest = DisqusBlacklistAddRequest
                .New(TestData.Forum)
                .Email(testEmail);

            await Disqus.Blacklists.AddAsync(DisqusAccessToken.Create(TestData.AccessToken), addBlacklistEntryRequest).ConfigureAwait(false);

            /* act */

            var request = DisqusBlacklistRemoveRequest
                .New(TestData.Forum)
                .Email(testEmail);

            /* act */

            var response = await Disqus.Blacklists.RemoveAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

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

            var addBlacklistEntryRequest = DisqusBlacklistAddRequest
                .New(TestData.Forum)
                .Email(testEmail);

            await Disqus.Blacklists.AddAsync(DisqusAccessToken.Create(TestData.AccessToken), addBlacklistEntryRequest).ConfigureAwait(false);

            var request = DisqusBlacklistListRequest
                .New(TestData.Forum)
                .Related(DisqusBlacklistEntryRelated.Forum);

            /* act */

            var response = await Disqus.Blacklists.ListAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* teardown */

            var removeBlacklistEntryRequest = DisqusBlacklistRemoveRequest
                .New(TestData.Forum)
                .Email(testEmail);

            await Disqus.Blacklists.RemoveAsync(DisqusAccessToken.Create(TestData.AccessToken), removeBlacklistEntryRequest).ConfigureAwait(false);
        }
    }
}
