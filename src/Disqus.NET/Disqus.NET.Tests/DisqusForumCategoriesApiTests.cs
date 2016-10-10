using System.Threading.Tasks;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusForumCategoriesApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task ListAsync_Tests()
        {
            var response = await Disqus.ForumCategory.ListAsync().ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        [TestCase(1)]
        public async Task DetailsAsync_Tests(int forumCategoryId)
        {
            var response = await Disqus.ForumCategory.DetailsAsync(forumCategoryId).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }
    }
}
