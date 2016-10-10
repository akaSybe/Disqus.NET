using System;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    public class DisqusTestsInitializer
    {
        private const string DisqusKey = "X06iuWTeIlPzxRByY43SXFQO3oBnFoYtJ8MHQQG6J8MOEoBiHIHJogK7A69whLs7";

        protected static class TestData
        {
            public const string AccessToken = "";
            public const string Forum = "";
            public const int UserId = 0;
            public const string UserName = "";
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
