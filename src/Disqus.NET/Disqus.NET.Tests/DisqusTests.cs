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

        public IDisqusApi Disqus;

        [OneTimeSetUp]
        public void Init()
        {
            if (string.IsNullOrWhiteSpace(DisqusKey))
            {
                throw new ArgumentNullException(DisqusKey, "You should explicit specify Disqus Secret Key!");    
            }

            if (string.IsNullOrWhiteSpace(AccessToken))
            {
                throw new ArgumentNullException(AccessToken, "You should explicit specify Disqus Access Token!");
            }

            Disqus = new DisqusApi(new DisqusRequestProcessor(new DisqusRestClient()), DisqusAuthMethod.SecretKey, DisqusKey);
        }

        [Test]
        public async Task GetDetailsAsync_If_UserIdIsValid_ShouldReturn_UserDetails()
        {
            int userId = 1;

            var result = await Disqus.GetUserDetailsAsync(userId).ConfigureAwait(false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task GetDetailsAsync_If_UsernameIsValid_ShouldReturn_UserDetails()
        {
            string username = "Jason";

            var result = await Disqus.GetUserDetailsAsync(username).ConfigureAwait(false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task GetDetailsAsync_If_InvalidParameter_ShouldReturn_ErrorResult()
        { 
            int userId = 0;

            ActualValueDelegate<Task<DisqusResponse<DisqusUser>>> del = async () => await Disqus.GetUserDetailsAsync(userId).ConfigureAwait(false);
            Assert.That(del, Throws.TypeOf<DisqusApiException>());
        }

        [Test]
        public async Task FollowAsync_If_UserIdIsValid_ShouldReturn_SuccessResult()
        {
            int userId = 211190711;

            await Disqus.FollowAsync(userId, AccessToken).ConfigureAwait(false);
        }

        [Test]
        public async Task FollowAsync_If_UsernameIsValid_ShouldReturn_SuccessResult()
        {
            string username = "disqus_uXBpgUxFhN";

            await Disqus.FollowAsync(username, AccessToken).ConfigureAwait(false);
        }

        [Test]
        public async Task UnfollowAsync_If_UserIdIsValid_ShouldReturn_SuccessResult()
        {
            int userId = 211190711;

            await Disqus.UnfollowAsync(userId, AccessToken).ConfigureAwait(false);
        }

        [Test]
        public async Task UnfollowAsync_If_UsernameIsValid_ShouldReturn_SuccessResult()
        {
            string username = "disqus_uXBpgUxFhN";

            await Disqus.UnfollowAsync(username, AccessToken).ConfigureAwait(false);
        }

        [Test]
        public async Task UpdateProfile_If_PassValidDetails_ShouldReturn_UserWithUpdatedDetails()
        {
            string name = "test";

            var response = await Disqus.UpdateProfileAsync(AccessToken, name).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.Not.Null);
            Assert.That(response.Response, Has.Property("Name").EqualTo(name));
        }

        [Test]
        public async Task CreateCategoryAsync_If_ParametersAreValid_ShouldReturn_CategoryDetails()
        {
            string forum = "sandbox-akasybe";
            string title = "test";

            var response = await Disqus.CreateCategoryAsync(AccessToken, forum, title).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        }

        [Test]
        public async Task GetCategoryDetailsAsync_If_CategoryIdIsValid_ShouldReturn_CategoryDetails()
        {
            int categoryId = 1;

            var response = await Disqus.GetCategoryDetailsAsync(categoryId).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        }

        [Test]
        public async Task GetCategoryListAsync_If_ParametersAreValid_ShouldReturn_CategoryList()
        {
            string forum = "sandbox-akasybe";

            var response = await Disqus.GetCategoryListAsync(forum).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        }

        [Test]
        [TestCase("the-flow2014", DisqusForumAttach.None, DisqusForumRelated.None)]
        [TestCase("the-flow2014", DisqusForumAttach.None, DisqusForumRelated.Author)]
        [TestCase("the-flow2014", DisqusForumAttach.Counters, DisqusForumRelated.None)]
        [TestCase("the-flow2014", DisqusForumAttach.FollowsForum, DisqusForumRelated.None)]
        [TestCase("the-flow2014", DisqusForumAttach.ForumForumCategory, DisqusForumRelated.None)]
        [TestCase("the-flow2014", DisqusForumAttach.ForumDaysAlive, DisqusForumRelated.None)]
        [TestCase("the-flow2014", DisqusForumAttach.ForumIntegration, DisqusForumRelated.None)]
        [TestCase("the-flow2014", DisqusForumAttach.Counters | DisqusForumAttach.FollowsForum, DisqusForumRelated.None)]
        public async Task GetForumDetailsAsync_Tests(string forum, DisqusForumAttach attach, DisqusForumRelated related)
        {
            var response = await Disqus.GetForumDetailsAsync(forum, attach, related).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));

            Assert.That(response.Response.Author, related != DisqusForumRelated.None ? Is.Not.Null : Is.Null);
        }

        [Test]
        public async Task GetForumCategoryListAsync_Tests()
        {
            var response = await Disqus.GetForumCategoryListAsync().ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        [TestCase(1)]
        public async Task GetForumCategoryDetailsAsync_Tests(int forumCategoryId)
        {
            var response = await Disqus.GetForumCategoryDetailsAsync(forumCategoryId).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }
    }
}
