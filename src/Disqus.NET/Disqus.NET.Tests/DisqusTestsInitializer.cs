using System;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    public class DisqusTestsInitializer
    {
        private const string DisqusKey = "";

        protected static class TestData
        {
            public const string AccessToken = "";
            public const string Forum = "";
            public const int UserId = 0;
            public const string UserName = "";
            public const int ModeratorUserId = 0;
            public const string ModeratorUserName = "";
        }

        protected IDisqusApi Disqus;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            if (string.IsNullOrWhiteSpace(DisqusKey))
            {
                throw new ArgumentNullException(DisqusKey, "You should explicit specify Disqus Secret Key!");
            }

            if (string.IsNullOrWhiteSpace(TestData.AccessToken))
            {
                throw new ArgumentNullException(TestData.AccessToken, "You should explicit specify Disqus Access Token!");
            }

            Disqus = new DisqusApi(new DisqusRequestProcessor(new DisqusRestClient()), DisqusAuthMethod.SecretKey, DisqusKey);
        }
    }
}
