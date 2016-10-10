using System.Threading.Tasks;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusCategoryApiTests : DisqusTestsInitializer
    {
        [Test]
        public async Task CreateAsync_Test()
        {
            string title = "test";

            var response = await Disqus.Category.CreateAsync(TestData.AccessToken, TestData.Forum, title).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response.Title, Is.EqualTo(title));
        }

        [Test]
        [TestCase(1)]
        public async Task DetailsAsync_Test(int forumCategoryId)
        {
            var response = await Disqus.Category.DetailsAsync(forumCategoryId).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Null);
        }

        [Test]
        public async Task ListAsync_If_ParametersAreValid_ShouldReturn_CategoryList()
        {
            var response = await Disqus.Category.ListAsync(TestData.Forum).ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
        }
    }
}
