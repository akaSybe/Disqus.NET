using System.Threading.Tasks;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusOrganizationsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task ListAsync_Test()
        {
            /* act */

            var response = await Disqus.Organizations
                .ListAdminsAsync(TestData.AccessToken, TestData.OrganizationId)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task AddAdminAsync_ByUserId_Test()
        {
            /* act */

            var response = await Disqus.Organizations
                .AddAdminAsync(TestData.AccessToken, TestData.OrganizationId, TestData.UserId)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.EqualTo(TestData.UserId));
        }

        [Test]
        public async Task AddAdminAsync_ByUserName_Test()
        {
            /* act */

            var response = await Disqus.Organizations
                .AddAdminAsync(TestData.AccessToken, TestData.OrganizationId, TestData.UserName)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Username, Is.EqualTo(TestData.UserName));
        }

        [Test]
        public async Task RemoveAdminAsync_ByUserId_Test()
        {
            /* act */

            var response = await Disqus.Organizations
                .RemoveAdminAsync(TestData.AccessToken, TestData.OrganizationId, TestData.UserId)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.EqualTo(TestData.UserId));
        }

        [Test]
        public async Task RemoveAdminAsync_ByUserName_Test()
        {
            /* act */

            var response = await Disqus.Organizations
                .RemoveAdminAsync(TestData.AccessToken, TestData.OrganizationId, TestData.UserName)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Username, Is.EqualTo(TestData.UserName));
        }

        [Test]
        public async Task SetRoleAsync_ByUserId_Test()
        {
            /* arrange */

            bool isModerator = true;
            bool isAdmin = false;

            /* act */

            var response = await Disqus.Organizations
                .SetRoleAsync(TestData.AccessToken, TestData.OrganizationId, TestData.UserId, isModerator, isAdmin)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.EqualTo(TestData.UserId));
        }

        [Test]
        public async Task SetRoleAsync_ByUserName_Test()
        {
            /* arrange */

            bool isModerator = true;
            bool isAdmin = false;

            /* act */

            var response = await Disqus.Organizations
                .SetRoleAsync(TestData.AccessToken, TestData.OrganizationId, TestData.UserName, isModerator, isAdmin)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Username, Is.EqualTo(TestData.UserName));
        }
    }
}
