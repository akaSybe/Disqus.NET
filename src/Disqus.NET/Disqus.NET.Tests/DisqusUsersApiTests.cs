using System;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusUsersApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task CheckUsernameAsync_Test()
        {
            /* arrange */

            string testUsername = Guid.NewGuid().ToString("N").Substring(0, 10);

            /* act */

            var response = await Disqus.Users
                .CheckUsernameAsync(DisqusAccessToken.Create(TestData.AccessToken), testUsername)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.EqualTo(testUsername));
        }

        [Test]
        public async Task DetailsAsync_ByUserId_Test()
        {
            var result = await Disqus.Users.DetailsAsync(TestData.UserId).ConfigureAwait(false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task DetailsAsync_By_Username_Test()
        {
            var result = await Disqus.Users.DetailsAsync(TestData.UserName).ConfigureAwait(false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task FollowAsync_ByUserId_Test()
        {
            await Disqus.Users
                .FollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserId)
                .ConfigureAwait(false);
        }

        [Test]
        public async Task FollowAsync_ByUsername_Test()
        {
            await Disqus.Users
                .FollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserName)
                .ConfigureAwait(false);
        }

        [Test]
        public async Task InterestingUsersAsync_Test()
        {
            var response = await Disqus.Users
                .InterestingUsersAsync(DisqusAccessToken.Create(TestData.AccessToken), 5)
                .ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListActivityAsync_Test()
        {
            /* arrange */

            var request = DisqusUserListActivityRequest
                .New();

            /* act */

            var response = await Disqus.Users
                .ListActivityAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListActiveForumsAsync_ByUserId_Test()
        {
            /* arrrange */

            var request = DisqusUserListActiveForumsRequest
                .New()
                .User(TestData.UserId)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListActiveForumsAsync(request)
                .ConfigureAwait(false);

            /* assert */
            
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListActiveForumsAsync_ByUserName_Test()
        {
            /* arrrange */

            var request = DisqusUserListActiveForumsRequest
                .New()
                .User(TestData.UserName)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListActiveForumsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListFollowersAsync_ByUserId_Test()
        {
            /* arrange */

            await Disqus.Users
                .FollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserId)
                .ConfigureAwait(false);

            var request = DisqusUserListFollowersRequest
                .New()
                .User(TestData.UserId)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListFollowersAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* tear down */

            await Disqus.Users
                .UnfollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserId)
                .ConfigureAwait(false);
        }

        [Test]
        public async Task ListFollowersAsync_ByUserName_Test()
        {
            /* arrange */

            await Disqus.Users
                .FollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserName)
                .ConfigureAwait(false);

            var request = DisqusUserListFollowersRequest
                .New()
                .User(TestData.UserName)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListFollowersAsync(request)
                .ConfigureAwait(false);
            
            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* tear down */

            await Disqus.Users
                .UnfollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserId)
                .ConfigureAwait(false);
        }

        [Test]
        public async Task ListFollowingAsync_ByUserId_Test()
        {
            /* arrange */

            await Disqus.Users
                .FollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserId)
                .ConfigureAwait(false);

            var request = DisqusUserListFollowingRequest
                .New()
                .User(TestData.UserName)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListFollowingAsync(request)
                .ConfigureAwait(false);

            /* tear down */

            await Disqus.Users
                .UnfollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserId)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListFollowingAsync_ByUserName_Test()
        {
            /* arrange */

            await Disqus.Users.FollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserName).ConfigureAwait(false);

            var request = DisqusUserListFollowingRequest
                .New()
                .User(TestData.ModeratorUserName)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListFollowingAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* tear down */

            await Disqus.Users
                .UnfollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserName)
                .ConfigureAwait(false);
        }

        [Test]
        public async Task ListFollowingForumsAsync_ByUserId_Test()
        {
            /* arrange */

            var request = DisqusUserListFollowingForumsRequest
                .New()
                .User(TestData.ModeratorUserId)
                .Attach(DisqusPostInclude.Approved)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListFollowingForumsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListFollowingForumAsync_ByUserName_Test()
        {
            /* arrange */

            var request = DisqusUserListFollowingForumsRequest
                .New()
                .User(TestData.ModeratorUserName)
                .Attach(DisqusPostInclude.Approved)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListFollowingForumsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListForumsAsync_ByUserId_Test()
        {
            /* arrange */

            var request = DisqusUserListForumsRequest
                .New()
                .User(TestData.ModeratorUserId)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListForumsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListForumsAsync_ByUserName_Test()
        {
            /* arrange */

            var request = DisqusUserListForumsRequest
                .New()
                .User(TestData.ModeratorUserName)
                .Limit(10)
                .Order(DisqusOrder.Asc);

            /* act */

            var response = await Disqus.Users
                .ListForumsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListMostActiveForumsAsync_ByUserId_Test()
        {
            /* arrange */

            var request = DisqusUserListMostActiveForumsRequest
                .New()
                .User(TestData.ModeratorUserId)
                .Limit(10);

            /* act */

            var response = await Disqus.Users
                .ListMostActiveForumsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListMostActiveForumsAsync_ByUserName_Test()
        {
            /* arrange */

            var request = DisqusUserListMostActiveForumsRequest
                .New()
                .User(TestData.ModeratorUserName)
                .Limit(10);

            /* act */

            var response = await Disqus.Users
                .ListMostActiveForumsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListPostAsync_ByAccessToken_Test()
        {
            /* arrange */

            var request = DisqusUserListPostsRequest
                .New();

            /* act */

            var response = await Disqus.Users
                .ListPostsAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListPostAsync_ByUserName_Test()
        {
            /* arrange */

            var request = DisqusUserListPostsRequest
                .New()
                .User(TestData.UserName);

            /* act */

            var response = await Disqus.Users
                .ListPostsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListPostAsync_ByUserId_Test()
        {
            /* arrange */

            var request = DisqusUserListPostsRequest
                .New()
                .User(TestData.UserId);

            /* act */

            var response = await Disqus.Users
                .ListPostsAsync(request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task RemoveFollowerAsync_ByUserId_Test()
        {
            /* act */

            var response = await Disqus.Users
                .RemoveFollowerAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserId)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Empty);
        }

        [Test]
        public async Task RemoveFollowerAsync_ByUserName_Test()
        {
            /* act */

            var response = await Disqus.Users
                .RemoveFollowerAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserName)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Empty);
        }

        [Test]
        public async Task UnfollowAsync_ByUserId_Test()
        {
            await Disqus.Users
                .UnfollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserId)
                .ConfigureAwait(false);
        }

        [Test]
        public async Task UnfollowAsync_ByUsername_Test()
        {
            await Disqus.Users
                .UnfollowAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.UserName)
                .ConfigureAwait(false);
        }

        [Test]
        public async Task UpdateProfile_Test()
        {
            /* arrange */

            string about = Guid.NewGuid().ToString("N");
            string location = Guid.NewGuid().ToString("N");
            string url = string.Format("http://{0}.com", Guid.NewGuid().ToString("N"));

            var request = DisqusUserUpdateProfileRequest
                .New()
                .Name(TestData.UserName)
                .About(about)
                .Location(location)
                .Url(url);

            /* act */

            var response = await Disqus.Users
                .UpdateProfileAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.Not.Null);
            Assert.That(response.Response.Name, Is.EqualTo(TestData.UserName));
            Assert.That(response.Response.Location, Is.EqualTo(location));
            Assert.That(response.Response.About, Is.EqualTo(about));
            Assert.That(response.Response.Url, Is.EqualTo(url));
        }
    }
}