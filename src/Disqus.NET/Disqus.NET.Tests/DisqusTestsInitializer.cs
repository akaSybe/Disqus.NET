using System;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    public class DisqusTestsInitializer
    {
        private const string DisqusKey = "87SwoQOoeN2PT1ys51TpLTMh4EcUwZm3736Ct57kFoh31uYIZNXejTBX0sPf9lXY";

        protected static class TestData
        {
            public const string AccessToken = "6b659e85ca6a4882a841b4791b564555";
            public const string Forum = "sandbox-akasybe";
            public const int UserId = 211190711;
            public const string UserName = "disqus_uXBpgUxFhN";
            public const int ModeratorUserId = 158824314;
            public const string ModeratorUserName = "akasybe";
            public const string TrustedDomain = "akasybe.github.io";
            public const int OrganizationId = 3202995;
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
