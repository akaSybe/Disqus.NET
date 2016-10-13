using System.Linq;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusThreadsApiTests : DisqusTestsInitializer
    {
        [Test]
        [TestCase("5164468291", DisqusThreadRelated.Category, DisqusThreadAttach.None)]
        [TestCase("5164468291", DisqusThreadRelated.Author, DisqusThreadAttach.None)]
        [TestCase("5164468291", DisqusThreadRelated.Forum, DisqusThreadAttach.None)]
        public async Task DetailsAsync_Test(string threadId, DisqusThreadRelated related, DisqusThreadAttach attach)
        {
            /* arrange */

            var request = DisqusThreadDetailsRequest
                .New(DisqusThreadLookupType.Id, threadId)
                .Related(related)
                .Attach(attach);

            /* act */

            var response = await Disqus.Threads.DetailsAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));

            if (related.HasFlag(DisqusThreadRelated.Category))
            {
                Assert.That(response.Response.Category.Id, Is.Not.EqualTo(0));
                Assert.That(response.Response.Category.Title, Is.Not.Null);
            }

            if (related.HasFlag(DisqusThreadRelated.Author))
            {
                Assert.That(response.Response.Author.Id, Is.Not.EqualTo(0));
            }

            if (related.HasFlag(DisqusThreadRelated.Forum))
            {
                Assert.That(response.Response.Forum.Id, Is.Not.Null);
            }
        }

        [Test]
        public async Task ListAsync_Test()
        {
            /* arrange */

            var request = DisqusThreadListRequest
                .New()
                .ByForums(TestData.Forum)
                .Related(DisqusThreadRelated.Forum);

            /* act */

            var response = await Disqus.Threads.ListAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListHotAsync_Test()
        {
            /* arrange */

            var request = DisqusThreadListHotRequest
                .New()
                .ByForums(TestData.Forum)
                .Related(DisqusThreadRelated.Forum);

            /* act */

            var response = await Disqus.Threads.ListHotAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListPopularAsync_Test()
        {
            /* arrange */

            var request = DisqusThreadListPopularRequest
                .New()
                .Forum("the-flow2014")
                .Related(DisqusThreadRelated.Forum);

            /* act */

            var response = await Disqus.Threads.ListPopularAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task ListUsersVotedThreadAsync_Test()
        {
            /* arrange */

            var request = DisqusThreadListUsersVotedThreadRequest
                .New(DisqusThreadLookupType.Id, "5216398900");

            /* act */

            var response = await Disqus.Threads.ListUsersVotedThreadAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
        }

        [Test]
        public async Task SetAsync_Test()
        {
            /* arrange */

            var request = DisqusThreadSetRequest
                .New(DisqusThreadLookupType.Id, "5218099631", "5217370326")
                .Related(DisqusThreadRelated.Forum);

            /* act */

            var response = await Disqus.Threads.SetAsync(request).ConfigureAwait(false);

            /* assert */

            Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(response.Response, Is.Not.Empty);
            Assert.That(response.Response.Count(), Is.EqualTo(2));
        }
    }
}
