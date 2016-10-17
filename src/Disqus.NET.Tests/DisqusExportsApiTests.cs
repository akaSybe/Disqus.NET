using System.Linq;
using System.Threading.Tasks;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusExportsApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task ExportForumAsync_Test()
        {
            /* arrange */
            
            var request = DisqusExportExportForumRequest
                .New(TestData.Forum);

            /* act */

            var response = await Disqus.Exports.ExportForumAsync(DisqusAccessToken.Create(TestData.AccessToken), request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        }
    }
}
