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

            var response = await Disqus.Users.CheckUsernameAsync(TestData.AccessToken, testUsername).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.EqualTo(testUsername));
        }

        [Test]
        public async Task DetailsAsync_If_UserIdIsValid_ShouldReturn_UserDetails()
        {
            var result = await Disqus.Users.DetailsAsync(TestData.UserId).ConfigureAwait(false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task DetailsAsync_If_UserNameIsValid_ShouldReturn_UserDetails()
        {
            var result = await Disqus.Users.DetailsAsync(TestData.UserName).ConfigureAwait(false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public void DetailsAsync_If_InvalidParameter_ShouldReturn_ErrorResult()
        {
            ActualValueDelegate<Task<DisqusResponse<DisqusUser>>> del = async () => await Disqus.Users.DetailsAsync(0).ConfigureAwait(false);
            Assert.That(del, Throws.TypeOf<DisqusApiException>());
        }

        [Test]
        public async Task FollowAsync_If_UserIdIsValid_ShouldReturn_SuccessResult()
        {
            await Disqus.Users.FollowAsync(TestData.AccessToken, TestData.UserId).ConfigureAwait(false);
        }

        [Test]
        public async Task FollowAsync_If_UserNameIsValid_ShouldReturn_SuccessResult()
        {
            await Disqus.Users.FollowAsync(TestData.AccessToken, TestData.UserName).ConfigureAwait(false);
        }

        [Test]
        public async Task InterestingUsersAsync_Tests()
        {
            var response = await Disqus.Users.InterestingUsersAsync(DisqusAccessToken.Create(TestData.AccessToken), 5).ConfigureAwait(false);

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

            var response = await Disqus.Users.ListActivityAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListActiveForumsAsync_ByUserId_Test()
        {
            /* act */

            var response = await Disqus.Users.ListActiveForumsAsync(TestData.UserId).ConfigureAwait(false);

            /* assert */
            
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListActiveForumsAsync_ByUserName_Test()
        {
            /* act */

            var response = await Disqus.Users.ListActiveForumsAsync(TestData.UserName).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }
        [Test]
        public async Task ListFollowersAsync_ByUserId_Test()
        {
            /* arrange */

            await Disqus.Users.FollowAsync(TestData.AccessToken, TestData.UserId).ConfigureAwait(false);

            /* act */

            var response = await Disqus.Users.ListFollowersAsync(TestData.UserId).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* tear down */

            await Disqus.Users.UnfollowAsync(TestData.AccessToken, TestData.UserId).ConfigureAwait(false);
        }

        [Test]
        public async Task ListFollowersAsync_ByUserName_Test()
        {
            /* arrange */

            await Disqus.Users.FollowAsync(TestData.AccessToken, TestData.UserName).ConfigureAwait(false);

            /* act */

            var response = await Disqus.Users.ListFollowersAsync(TestData.UserName).ConfigureAwait(false);
            
            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* tear down */

            await Disqus.Users.UnfollowAsync(TestData.AccessToken, TestData.UserId).ConfigureAwait(false);
        }

        [Test]
        public async Task ListFollowingAsync_ByUserId_Test()
        {
            /* arrange */

            await Disqus.Users.FollowAsync(TestData.AccessToken, TestData.UserId).ConfigureAwait(false);

            /* act */

            var response = await Disqus.Users.ListFollowingAsync(TestData.ModeratorUserId).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* tear down */

            await Disqus.Users.UnfollowAsync(TestData.AccessToken, TestData.UserId).ConfigureAwait(false);
        }

        [Test]
        public async Task ListFollowingAsync_ByUserName_Test()
        {
            /* arrange */

            await Disqus.Users.FollowAsync(TestData.AccessToken, TestData.UserName).ConfigureAwait(false);

            /* act */

            var response = await Disqus.Users.ListFollowingAsync(TestData.ModeratorUserName).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);

            /* tear down */

            await Disqus.Users.UnfollowAsync(TestData.AccessToken, TestData.UserName).ConfigureAwait(false);
        }

        [Test]
        public async Task ListFollowingForumsAsync_ByUserId_Test()
        {
            /* act */

            var response = await Disqus.Users.ListFollowingForumsAsync(TestData.ModeratorUserId).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListFollowingForumAsync_ByUserName_Test()
        {
            /* act */

            var response = await Disqus.Users.ListFollowingForumsAsync(TestData.ModeratorUserName).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListForumsAsync_ByUserId_Test()
        {
            /* act */

            var response = await Disqus.Users.ListForumsAsync(TestData.ModeratorUserId).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListForumsAsync_ByUserName_Test()
        {
            /* act */

            var response = await Disqus.Users.ListForumsAsync(TestData.ModeratorUserName).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListMostActiveForumsAsync_ByUserId_Test()
        {
            /* act */

            var response = await Disqus.Users.ListMostActiveForumsAsync(TestData.ModeratorUserId).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListMostActiveForumsAsync_ByUserName_Test()
        {
            /* act */

            var response = await Disqus.Users.ListMostActiveForumsAsync(TestData.ModeratorUserName).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListPostAsync_ByAccessToken_Test()
        {
            /* arrange */

            var request = DisqusUsersListPostsRequest
                .New();

            /* act */

            var response = await Disqus.Users.ListPostsAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListPostAsync_ByUserName_Test()
        {
            /* arrange */

            var request = DisqusUsersListPostsRequest
                .New()
                .User(TestData.UserName);

            /* act */

            var response = await Disqus.Users.ListPostsAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListPostAsync_ByUserId_Test()
        {
            /* arrange */

            var request = DisqusUsersListPostsRequest
                .New()
                .User(TestData.UserId);

            /* act */

            var response = await Disqus.Users.ListPostsAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task RemoveFollowerAsync_ByUserId_Test()
        {
            /* act */

            var response = await Disqus.Users.RemoveFollowerAsync(TestData.AccessToken, TestData.UserId).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Empty);
        }

        [Test]
        public async Task RemoveFollowerAsync_ByUserName_Test()
        {
            /* act */

            var response = await Disqus.Users.RemoveFollowerAsync(TestData.AccessToken, TestData.UserName).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Empty);
        }

        [Test]
        public async Task UnfollowAsync_If_UserIdIsValid_ShouldReturn_SuccessResult()
        {
            await Disqus.Users.UnfollowAsync(TestData.AccessToken, TestData.UserId).ConfigureAwait(false);
        }

        [Test]
        public async Task UnfollowAsync_If_UsernameIsValid_ShouldReturn_SuccessResult()
        {
            await Disqus.Users.UnfollowAsync(TestData.AccessToken, TestData.UserName).ConfigureAwait(false);
        }

        [Test]
        public async Task UpdateProfile_Test()
        {
            var response = await Disqus.Users.UpdateProfileAsync(TestData.AccessToken, TestData.UserName).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.Not.Null);
            Assert.That(response.Response, Has.Property("Name").EqualTo(TestData.UserName));
        }
    }
}