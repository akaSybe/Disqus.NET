using System.Threading.Tasks;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusOrganizationsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task ListAsync_Test()
        {
            /* arrange */

            /* act */

            var response = await Disqus.Organizations
                .ListAdminsAsync(DisqusAccessToken.Create(TestData.AccessToken), TestData.OrganizationId)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task AddAdminAsync_ByUserId_Test()
        {
            /* arrange */

            var request = DisqusOrganizationAddAdminRequest
                .New(TestData.OrganizationId, TestData.UserId);

            /* act */

            var response = await Disqus.Organizations
                .AddAdminAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.EqualTo(TestData.UserId));
        }

        [Test]
        public async Task AddAdminAsync_ByUserName_Test()
        {
            /* arrange */

            var request = DisqusOrganizationAddAdminRequest
                .New(TestData.OrganizationId, TestData.UserName);

            /* act */

            var response = await Disqus.Organizations
                .AddAdminAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Username, Is.EqualTo(TestData.UserName));
        }

        [Test]
        public async Task RemoveAdminAsync_ByUserId_Test()
        {
            /* arrange */

            var request = DisqusOrganizationRemoveAdminRequest
                .New(TestData.OrganizationId, TestData.ModeratorUserId);

            /* act */

            var response = await Disqus.Organizations
                .RemoveAdminAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.EqualTo(TestData.ModeratorUserId));
        }

        [Test]
        public async Task RemoveAdminAsync_ByUserName_Test()
        {
            /* arrange */

            var request = DisqusOrganizationRemoveAdminRequest
                .New(TestData.OrganizationId, TestData.ModeratorUserName);

            /* act */

            var response = await Disqus.Organizations
                .RemoveAdminAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Username, Is.EqualTo(TestData.ModeratorUserName));
        }

        [Test]
        public async Task SetRoleAsync_ByUserId_Test()
        {
            /* arrange */

            var request = DisqusOrganizationSetRoleRequest
                .New(TestData.OrganizationId, TestData.UserId)
                .IsAdmin()
                .IsModerator();

            /* act */

            var response = await Disqus.Organizations
                .SetRoleAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Id, Is.EqualTo(TestData.UserId));
        }

        [Test]
        public async Task SetRoleAsync_ByUserName_Test()
        {
            /* arrange */

            var request = DisqusOrganizationSetRoleRequest
                .New(TestData.OrganizationId, TestData.UserName)
                .IsAdmin()
                .IsModerator();

            /* act */

            var response = await Disqus.Organizations
                .SetRoleAsync(DisqusAccessToken.Create(TestData.AccessToken), request)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Username, Is.EqualTo(TestData.UserName));
        }
    }
}
