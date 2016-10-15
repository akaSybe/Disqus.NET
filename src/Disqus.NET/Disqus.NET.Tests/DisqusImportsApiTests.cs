using System.Threading.Tasks;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusImportsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task Details_Async()
        {
            /* arrange */

            string forum = "disqus";
            string group = "74817";

            /* act */

            var response = await Disqus.Imports
                .DetailsAsync(DisqusAccessToken.Create(TestData.AccessToken), forum, group)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
            Assert.That(response.Response.Forum, Is.EqualTo(forum));
            Assert.That(response.Response.Id, Is.EqualTo(group));
        }

        [Test]
        public async Task List_Async()
        {
            /* arrange */

            string forum = "disqus";

            /* act */

            var response = await Disqus.Imports
                .ListAsync(DisqusAccessToken.Create(TestData.AccessToken), forum)
                .ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }
    }
}
