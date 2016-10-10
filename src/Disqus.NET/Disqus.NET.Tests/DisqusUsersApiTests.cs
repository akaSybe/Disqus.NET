using System.Threading.Tasks;
using Disqus.NET.Models;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusUsersApiTests : DisqusTestsInitializer
    {
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