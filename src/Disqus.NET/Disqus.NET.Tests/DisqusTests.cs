using System;
using System.Threading.Tasks;
using Disqus.NET.Models;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusTests
    {
        private const string DisqusKey = "";
        private const string AccessToken = "";

        public IDisqusApi Api;

        [OneTimeSetUp]
        public void Init()
        {
            if (string.IsNullOrWhiteSpace(DisqusKey))
            {
                throw new ArgumentNullException(DisqusKey, "You should explicit specify Disqus Secret Key!");    
            }

            if (string.IsNullOrWhiteSpace(AccessToken))
            {
                throw new ArgumentNullException(DisqusKey, "You should explicit specify Disqus Access Token!");
            }

            Api = new DisqusApi(new DisqusRequestProcessor(new DisqusRestClient()), DisqusAuthMethod.SecretKey, DisqusKey);
        }

        [Test]
        public async Task GetDetailsAsync_If_UserIdIsValid_ShouldReturn_UserDetails()
        {
            int userId = 1;

            var result = await Api.GetUserDetailsAsync(userId).ConfigureAwait(false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task GetDetailsAsync_If_UsernameIsValid_ShouldReturn_UserDetails()
        {
            string username = "Jason";

            var result = await Api.GetUserDetailsAsync(username).ConfigureAwait(false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task GetDetailsAsync_If_InvalidParameter_ShouldReturn_ErrorResult()
        { 
            int userId = 0;

            ActualValueDelegate<Task<DisqusResponse<DisqusUser>>> del = async () => await Api.GetUserDetailsAsync(userId).ConfigureAwait(false);
            Assert.That(del, Throws.TypeOf<DisqusApiException>());
        }

        [Test]
        public async Task FollowAsync_If_UserIdIsValid_ShouldReturn_SuccessResult()
        {
            int userId = 211190711;

            await Api.FollowAsync(userId, AccessToken).ConfigureAwait(false);
        }

        [Test]
        public async Task FollowAsync_If_UsernameIsValid_ShouldReturn_SuccessResult()
        {
            string username = "disqus_uXBpgUxFhN";

            await Api.FollowAsync(username, AccessToken).ConfigureAwait(false);
        }

        [Test]
        public async Task UnfollowAsync_If_UserIdIsValid_ShouldReturn_SuccessResult()
        {
            int userId = 211190711;

            await Api.UnfollowAsync(userId, AccessToken).ConfigureAwait(false);
        }

        [Test]
        public async Task UnfollowAsync_If_UsernameIsValid_ShouldReturn_SuccessResult()
        {
            string username = "disqus_uXBpgUxFhN";

            await Api.UnfollowAsync(username, AccessToken).ConfigureAwait(false);
        }

        [Test]
        public async Task UpdateProfile_If_PassValidDetails_ShouldReturn_UserWithUpdatedDetails()
        {
            string name = "test";

            var response = await Api.UpdateProfileAsync(AccessToken, name).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.Not.Null);
            Assert.That(response.Response, Has.Property("Name").EqualTo(name));
        }

        [Test]
        public async Task GetPostDetailsAsync_If_PostIdIsValid_ShouldReturn_PostDetails()
        {
            string postId = "2735004415";

            var response = await Api.GetPostDetailsAsync(postId).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        }
    }
}
