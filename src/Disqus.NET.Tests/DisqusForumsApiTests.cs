using System;
using System.Collections;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusForumsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task CreateAsync_Test()
        {
            /* arrange */

            string forumId = Guid.NewGuid().ToString("N");
            string forumName = "Test Forum";
            string forumDescription = "Test Description";
            string forumGuidelines = "Test Guidelines";
            string forumLanguage = "en";

            var request = DisqusForumCreateRequest
                .New(forumName, forumId)
                .Attach(DisqusForumAttach.ForumForumCategory)
                .Guidelines(forumGuidelines)
                .Description(forumDescription)
                .Language(forumLanguage);

            /* act */

            var response = await Disqus.Forums.CreateAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.EqualTo(forumId));
            Assert.That(response.Response.Name, Is.EqualTo(forumName));
            Assert.That(response.Response.RawDescription, Is.EqualTo(forumDescription));
            Assert.That(response.Response.RawGuidelines, Is.EqualTo(forumGuidelines));
            Assert.That(response.Response.Language, Is.EqualTo(forumLanguage));
        }

        private class ForumDetailsTestData
        {
            public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.None, DisqusForumRelated.None, TestData.AccessToken);
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.None, DisqusForumRelated.None, null);
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.None, DisqusForumRelated.Author, null);
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.Counters, DisqusForumRelated.None, null);
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.FollowsForum, DisqusForumRelated.None, null);
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.ForumForumCategory, DisqusForumRelated.None, null);
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.ForumDaysAlive, DisqusForumRelated.None, null);
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.ForumIntegration, DisqusForumRelated.None, null);
                yield return new TestCaseData(TestData.Forum, DisqusForumAttach.Counters | DisqusForumAttach.FollowsForum, DisqusForumRelated.None, null);

            }
        }
    }
    [Test, TestCaseSource(typeof(ForumDetailsTestData), nameof(ForumDetailsTestData.TestCases))]
    public async Task DetailsAsync_Tests(string forum, DisqusForumAttach attach, DisqusForumRelated related, string accessToken)
    {
        /* arrange */

        var request = DisqusForumDetailsRequest
            .New(forum)
            .Attach(attach)
            .Related(related);

        /* act */

        DisqusResponse<DisqusForum> response;

        if (string.IsNullOrEmpty(accessToken))
        {
            response = await Disqus.Forums
                .DetailsAsync(request)
                .ConfigureAwait(false);
        }
        else
        {
            var disqusAccessToken = DisqusAccessToken.Create(accessToken);

            response = await Disqus.Forums
                .DetailsAsync(disqusAccessToken, request)
                .ConfigureAwait(false);
        }

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));

        Assert.That(response.Response.Author, related != DisqusForumRelated.None ? Is.Not.Null : Is.Null);
    }

    [Test]
    public async Task DisableAdsAsync_Tests()
    {
        var response = await Disqus.Forums.DisableAdsAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.Forum).ConfigureAwait(false);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response.Id, Is.EqualTo(TestData.Forum));
    }

    [Test]
    public async Task InterestingForumsAsync_Tests()
    {
        var response = await Disqus.Forums.InterestingForumsAsync(DisqusAccessToken.Create(TestData.AccessToken), 5).ConfigureAwait(false);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Empty);
    }

    [Test]
    public async Task ListCategoriesAsync_Tests()
    {
        /* arrange */

        var request = DisqusForumListCategoriesRequest
            .New(TestData.Forum)
            .Limit(10)
            .Order(DisqusOrder.Asc)
            .SinceId(1);

        /* act */

        var response = await Disqus.Forums
            .ListCategoriesAsync(request)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Empty);
    }

    [Test]
    public async Task ListFollowersAsync_Tests()
    {
        /* arrange */

        var request = DisqusForumListFollowersRequest
            .New(TestData.Forum)
            .Limit(10)
            .Order(DisqusOrder.Asc)
            .SinceId(1);

        /* act */

        var response = await Disqus.Forums
            .ListFollowersAsync(request)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Null);
    }

    [Test]
    public async Task ListModeratorsAsync_Tests()
    {
        /* act */

        var response = await Disqus.Forums
            .ListModeratorsAsync(TestData.Forum)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Null);
    }

    [Test]
    public async Task ListMostActiveUsersAsync_Test()
    {
        /* arrange */

        var request = DisqusForumListMostActiveUsersRequest
            .New(TestData.Forum)
            .Limit(10)
            .Order(DisqusOrder.Desc);

        /* act */

        var response = await Disqus.Forums
            .ListMostActiveUsersAsync(request)
            .ConfigureAwait(false);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Empty);
    }

    [Test]
    public async Task ListMostLikedUsersAsync_Tests()
    {
        /* arrange */

        var request = DisqusForumListMostLikedUsersRequest
            .New(TestData.Forum)
            .Limit(10)
            .Order(DisqusOrder.Desc);

        /* act */

        var response = await Disqus.Forums
            .ListMostLikedUsersAsync(request)
            .ConfigureAwait(false);

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
            .New(TestData.Forum)
            .Include(DisqusThreadInclude.Open)
            .Limit(10)
            .Related(DisqusCategoryListThreadRelated.Author | DisqusCategoryListThreadRelated.Forum)
            .Since(new DateTime(2016, 09, 01, 0, 0, 0))
            .Order(DisqusOrder.Asc);

        /* act */

        var response = await Disqus.Forums.ListThreadsAsync(request).ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Empty);
    }

    [Test]
    public async Task ListUsersAsync_Tests()
    {
        /* arrange */

        var request = DisqusForumListUsersRequest
            .New(TestData.Forum)
            .Limit(10)
            .Order(DisqusOrder.Asc)
            .SinceId(TestData.UserId);

        /* act */

        var response = await Disqus.Forums
            .ListUsersAsync(request)
            .ConfigureAwait(false);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Null);
    }

    [Test]
    public async Task AddModeratorAsync_ByUsername_Test()
    {
        /* arrange */

        bool canAdminister = true;
        bool canEdit = true;

        var request = DisqusForumAddModeratorRequest
            .New(TestData.Forum, TestData.UserName)
            .CanAdminister(canAdminister)
            .CanEdit(canEdit);

        /* act */

        var response = await Disqus.Forums
            .AddModeratorAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Null);
        Assert.That(response.Response.User.Username, Is.EqualTo(TestData.UserName));
    }

    [Test]
    public async Task AddModeratorAsync_ByUserId_Test()
    {
        /* arrange */

        bool canAdminister = true;
        bool canEdit = true;

        var request = DisqusForumAddModeratorRequest
            .New(TestData.Forum, TestData.UserId)
            .CanAdminister(canAdminister)
            .CanEdit(canEdit);

        /* act */

        var response = await Disqus.Forums
            .AddModeratorAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Not.Null);
    }

    [Test]
    public async Task RemoveModeratorAsync_ByModeratorId_Test()
    {
        /* arrange */

        var addModeratorRequest = DisqusForumAddModeratorRequest
            .New(TestData.Forum, TestData.UserId);

        var moderator = await Disqus.Forums
            .AddModeratorAsync(DisqusAccessToken.Create(TestData.AccessToken), addModeratorRequest)
            .ConfigureAwait(false);

        var request = DisqusForumRemoveModeratorRequest
            .New()
            .Moderator(moderator.Response.Id);

        /* act */

        var response = await Disqus.Forums
            .RemoveModeratorAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response.Id, Is.Null);
    }

    [Test]
    public async Task RemoveModeratorAsync_ByUserId_Test()
    {
        /* arrange */

        var addModeratorRequest = DisqusForumAddModeratorRequest
            .New(TestData.Forum, TestData.UserId);

        var moderator = await Disqus.Forums
            .AddModeratorAsync(DisqusAccessToken.Create(TestData.AccessToken), addModeratorRequest)
            .ConfigureAwait(false);

        var request = DisqusForumRemoveModeratorRequest
            .New()
            .User(moderator.Response.User.Id);

        /* act */

        var response = await Disqus.Forums
            .RemoveModeratorAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response.Id, Is.Null);
    }

    [Test]
    public async Task RemoveModeratorAsync_ByUserName_Test()
    {
        /* arrange */

        var addModeratorRequest = DisqusForumAddModeratorRequest
            .New(TestData.Forum, TestData.UserName);

        var moderator = await Disqus.Forums
            .AddModeratorAsync(DisqusAccessToken.Create(TestData.AccessToken), addModeratorRequest)
            .ConfigureAwait(false);

        var request = DisqusForumRemoveModeratorRequest
            .New()
            .User(moderator.Response.User.Username);

        /* act */

        var response = await Disqus.Forums
            .RemoveModeratorAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response.Id, Is.Null);
    }

    [Test]
    public async Task FollowForumAsync_Test()
    {
        var response = await Disqus.Forums
            .FollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.Forum)
            .ConfigureAwait(false);

        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Empty);
    }

    [Test]
    public async Task UnfollowForumAsync_Test()
    {
        var response = await Disqus.Forums
            .UnfollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.Forum)
            .ConfigureAwait(false);

        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        Assert.That(response.Response, Is.Empty);
    }

    [Test]
    public async Task UpdateAsync_Test()
    {
        /* arrange */

        string forumName = "Test Forum";
        string forumDescription = "Test Description";
        string forumGuidelines = "Test Guidelines";
        string forumLanguage = "en";

        var request = DisqusForumUpdateRequest
            .New(TestData.Forum)
            .Name(forumName)
            .Attach(DisqusForumAttach.ForumForumCategory)
            .Guidelines(forumGuidelines)
            .Description(forumDescription);

        /* act */

        var response = await Disqus.Forums.UpdateAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

        /* assert */

        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success)); ;
        Assert.That(response.Response.Name, Is.EqualTo(forumName));
        Assert.That(response.Response.RawDescription, Is.EqualTo(forumDescription));
        Assert.That(response.Response.RawGuidelines, Is.EqualTo(forumGuidelines));
        Assert.That(response.Response.Language, Is.EqualTo(forumLanguage));
    }

    [Test]
    public async Task ValidateAsync_Test()
    {
        /* arrange */

        var request = DisqusForumValidateRequest
            .New(TestData.Forum)
            .AdsPositionTopEnabled(true)
            .AdsProductLinksEnabled(true);

        /* act */

        var response = await Disqus.Forums
            .ValidateAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
    }

    [Test]
    public async Task RemoveDefaultAvatarAsync_Test()
    {
        /* act */

        var response = await Disqus.Forums
            .RemoveDefaultAvatarAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.Forum)
            .ConfigureAwait(false);

        /* assert */

        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
    }
}
}
