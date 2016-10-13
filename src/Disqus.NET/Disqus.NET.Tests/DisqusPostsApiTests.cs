using System.Threading.Tasks;
using Disqus.NET.Models;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    //[TestFixture]
    //public class DisqusPostsApiTests : DisqusTestsInitializer
    //{
    //    [Test]
    //    //[TestCase("2735004415", DisqusPostRelated.None)]
    //    //[TestCase("2735004415", DisqusPostRelated.Forum)]
    //    //[TestCase("2735004415", DisqusPostRelated.Thread)]
    //    [TestCase("2735004415", DisqusPostRelated.Thread | DisqusPostRelated.Forum)]
    //    public async Task DetailsAsync_Test(string postId, DisqusPostRelated related)
    //    {
    //        var response = await Disqus.Posts.DetailsAsync(postId, related).ConfigureAwait(false);

    //        Assert.That(response, Is.Not.Null);
    //        Assert.That(response.Code, Is.EqualTo(DisqusApiResponseCode.Success));

    //        if (related.HasFlag(DisqusPostRelated.Forum))
    //        {
    //            Assert.That(response.Response.Forum.Name, Is.Not.Null);
    //        }

    //        if (related.HasFlag(DisqusPostRelated.Thread))
    //        {
    //            //Assert.That(response.Response.Thread, Is.Not.Null);
    //        }
    //    }
    //}
}
