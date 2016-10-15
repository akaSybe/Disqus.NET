using System;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusPostsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task CreateAsync_Test()
        {
            /* arrange */

            var request = DisqusPostCreateRequest
                .New("test message")
                .Thread("4900766006");

            /* act */

            var response = await Disqus.Posts.CreateAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Thread.Id, Is.EqualTo(TestData.ThreadId));
        }

        [Test]
        public async Task DetailsAsync_Test()
        {
            /* arrange */

            var request = DisqusPostDetailsRequest
                .New(TestData.PostId)
                .Related(DisqusPostRelated.Forum | DisqusPostRelated.Thread);

            /* act */

            var response = await Disqus.Posts.DetailsAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Forum.Name, Is.Not.Null);
            Assert.That(response.Response.Thread, Is.Not.Null);
        }

        [Test]
        public async Task GetContextAsync_Test()
        {
            /* arrange */

            var request = DisqusPostGetContextRequest
                .New(TestData.PostId)
                .Depth(4);

            /* act */

            var response = await Disqus.Posts.GetContextAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListAsync_Test()
        {
            /* arrange */

            var request = DisqusPostListRequest
                .New()
                .Forum(TestData.Forum)
                .Related(DisqusPostRelated.Forum | DisqusPostRelated.Thread);

            /* act */

            var response = await Disqus.Posts.ListAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListPopularAsync_Test()
        {
            /* arrange */

            var request = DisqusPostListPopularRequest
                .New()
                .Forum(TestData.Forum)
                .Related(DisqusPostRelated.Forum | DisqusPostRelated.Thread);

            /* act */

            var response = await Disqus.Posts.ListPopularAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task RemoveAsync_Test()
        {
            /* arrange */

            var createPostRequest = DisqusPostCreateRequest
                .New(Guid.NewGuid().ToString("N"))
                .Thread(TestData.ThreadId);

            var createdPost = await Disqus.Posts.CreateAsync(DisqusAccessToken.Create(TestData.AccessToken), createPostRequest).ConfigureAwait(false);

            /* act */

            var response = await Disqus.Posts.RemoveAsync(DisqusAccessToken.Create(TestData.AccessToken), createdPost.Response.Id).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task RestoreAsync_Test()
        {
            /* arrange */

            await Disqus.Posts
                .RemoveAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.PostId)
                .ConfigureAwait(false);

            /* act */

            var response = await Disqus.Posts
                .RestoreAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.PostId)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task UpdateAsync_Test()
        {
            /* arrange */

            string postMessage = "updated message";

            /* act */

            var response = await Disqus.Posts
                .UpdateAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.PostId, postMessage)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.RawMessage, Is.EqualTo(postMessage));
        }

        [Test]
        public async Task VoteAsync_Test()
        {
            /* act */

            var response = await Disqus.Posts
                .VoteAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.PostId, DisqusVote.Vote)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Post.Likes, Is.EqualTo(1));
        }
    }
}
