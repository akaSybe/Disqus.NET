using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusForumsApiTests: DisqusTestsInitializer
    {
        [Test]
        [TestCase(TestData.Forum, DisqusForumAttach.None, DisqusForumRelated.None)]
        [TestCase(TestData.Forum, DisqusForumAttach.None, DisqusForumRelated.Author)]
        [TestCase(TestData.Forum, DisqusForumAttach.Counters, DisqusForumRelated.None)]
        [TestCase(TestData.Forum, DisqusForumAttach.FollowsForum, DisqusForumRelated.None)]
        [TestCase(TestData.Forum, DisqusForumAttach.ForumForumCategory, DisqusForumRelated.None)]
        [TestCase(TestData.Forum, DisqusForumAttach.ForumDaysAlive, DisqusForumRelated.None)]
        [TestCase(TestData.Forum, DisqusForumAttach.ForumIntegration, DisqusForumRelated.None)]
        [TestCase(TestData.Forum, DisqusForumAttach.Counters | DisqusForumAttach.FollowsForum, DisqusForumRelated.None)]
        public async Task DetailsAsync_Tests(string forum, DisqusForumAttach attach, DisqusForumRelated related)
        {
            var response = await Disqus.Forums.DetailsAsync(forum, attach, related).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));

            Assert.That(response.Response.Author, related != DisqusForumRelated.None ? Is.Not.Null : Is.Null);
        }

        [Test]
        [TestCase(TestData.Forum, null, null, 25, DisqusOrder.Asc)]
        public async Task ListCategoriesAsync_Tests(string forum, string sinceId, string cursor, int limit, DisqusOrder order)
        {
            var response = await Disqus.Forums.ListCategoriesAsync(forum, sinceId, cursor, limit, order).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        [TestCase(TestData.Forum, null, null, 25, DisqusOrder.Asc)]
        public async Task ListFollowersAsync_Tests(string forum, string sinceId, string cursor, int limit, DisqusOrder order)
        {
            var response = await Disqus.Forums.ListFollowersAsync(forum, sinceId, cursor, limit, order).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        [TestCase(TestData.Forum)]
        public async Task ListModeratorsAsync_Tests(string forum)
        {
            var response = await Disqus.Forums.ListModeratorsAsync(forum).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        [TestCase(TestData.Forum, 25, DisqusOrder.Desc, null)]
        public async Task ListMostActiveUsersAsync_Tests(string forum, int limit, DisqusOrder order, string cursor)
        {
            var response = await Disqus.Forums.ListMostActiveUsersAsync(forum, cursor, limit, order).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        [TestCase(TestData.Forum, 25, DisqusOrder.Desc, null)]
        public async Task ListMostLikedUsersAsync_Tests(string forum, int limit, DisqusOrder order, string cursor)
        {
            var response = await Disqus.Forums.ListMostLikedUsersAsync(forum, cursor, limit, order).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        public async Task ListPostsAsync_Tests()
        {
            /* arrange */

            var request = DisqusForumListPostsRequest
                .New(TestData.Forum);

            /* act */

            var response = await Disqus.Forums.ListPostsAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        public async Task ListThreadsAsync_Tests()
        {
            /* arrange */

            var request = DisqusForumListThreadsRequest
                .New(TestData.Forum);

            /* act */

            var response = await Disqus.Forums.ListThreadsAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        [TestCase(TestData.Forum, 25, DisqusOrder.Desc, null, null)]
        public async Task ListUsersAsync_Tests(string forum, int limit, DisqusOrder order, string sinceId, string cursor)
        {
            var response = await Disqus.Forums.ListUsersAsync(forum, sinceId, cursor, limit, order).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        [TestCase(TestData.Forum, TestData.UserId, null, null)]
        public async Task AddModeratorAsync_ByUserId_Tests(string forum, int userId, bool? canAdminister, bool? canEdit)
        {
            var response = await Disqus.Forums.AddModeratorAsync(TestData.AccessToken, forum, userId, canAdminister, canEdit).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
            Assert.That(response.Response.User.Id, Is.EqualTo(userId));
        }

        [Test]
        [TestCase(TestData.Forum, TestData.UserName, null, null)]
        public async Task AddModeratorAsync_ByUserId_Tests(string forum, string userName, bool? canAdminister, bool? canEdit)
        {
            var response = await Disqus.Forums.AddModeratorAsync(TestData.AccessToken, forum, userName, canAdminister, canEdit).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        public async Task RemoveModeratorAsync_ByModeratorId_Test()
        {
            /* arrange */

            var moderator = await Disqus.Forums.AddModeratorAsync(TestData.AccessToken, TestData.Forum, TestData.UserId).ConfigureAwait(false);

            /* act */

            var response = await Disqus.Forums.RemoveModeratorAsync(TestData.AccessToken, moderator.Response.Id).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.Null);
        }

        [Test]
        public async Task RemoveModeratorAsync_ByUserId_Test()
        {
            /* arrange */

            var moderator = await Disqus.Forums.AddModeratorAsync(TestData.AccessToken, TestData.Forum, TestData.UserId).ConfigureAwait(false);

            /* act */

            var response = await Disqus.Forums.RemoveModeratorAsync(TestData.AccessToken, TestData.Forum, moderator.Response.User.Id).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.Null);
        }

        [Test]
        public async Task RemoveModeratorAsync_ByUserName_Test()
        {
            /* arrange */

            var moderator = await Disqus.Forums.AddModeratorAsync(TestData.AccessToken, TestData.Forum, TestData.UserName).ConfigureAwait(false);

            /* act */

            var response = await Disqus.Forums.RemoveModeratorAsync(TestData.AccessToken, TestData.Forum, moderator.Response.User.Username).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.Null);
        }

        [Test]
        public async Task FollowForumAsync_Test()
        {
            var response = await Disqus.Forums.FollowAsync(TestData.AccessToken, TestData.Forum).ConfigureAwait(false);

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Empty);
        }

        [Test]
        public async Task UnfollowForumAsync_Test()
        {
            var response = await Disqus.Forums.UnfollowAsync(TestData.AccessToken, TestData.Forum).ConfigureAwait(false);

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Empty);
        }
    }
}
