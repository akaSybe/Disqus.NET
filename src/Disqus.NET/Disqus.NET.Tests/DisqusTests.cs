using System.Threading.Tasks;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    [TestFixture]
    public class DisqusTests
    {
        private IDisqusUsersApi _users;

        [SetUp]
        public void Init()
        {
            _users = new Users();   
        }

        [Test]
        public async Task GetDetailsAsync_ShouldReturnUserDetails()
        {
            int userId = 114880676;

            var result = await _users.GetDetailsAsync(userId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task GetDetailsAsync_Should_ReturnUser_When_UsernameIsValid()
        {
            string username = "";

            var result = await _users.GetDetailsAsync(username);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task GetDetailsAsync_InvalidParameter_ShouldReturnErrorResult()
        {
            int userId = 0; //114880676;

            var result = await _users.GetDetailsAsync(userId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Code, Is.Not.EqualTo(DisqusApiResponseCode.Success));
            Assert.That(result.Response, Is.Null);
        }
    }
}
