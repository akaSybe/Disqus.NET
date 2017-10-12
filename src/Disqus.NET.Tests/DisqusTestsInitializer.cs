using System;
using NUnit.Framework;

namespace Disqus.NET.Tests
{
    public class DisqusTestsInitializer
    {
        protected class DisqusTestVariables
        {
            public string SecretKey { get; }
            public string AccessToken { get; }
            public int ApplicationId { get; }
            public int CategoryId { get; }
            public string Forum { get; }
            public int UserId { get; }
            public string UserName { get; }
            public int ModeratorUserId { get; }
            public string ModeratorUserName { get; }
            public int OrganizationId { get; }
            public long PostId { get; }
            public string ThreadId { get; }
            public string TrustedDomain { get; }

            public DisqusTestVariables()
            {
                string secretKey = Environment.GetEnvironmentVariable("disqus.net:secret-key");
                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new Exception("Environment variable \"disqus.net:secret-key\" not found");
                }

                string accessToken = Environment.GetEnvironmentVariable("disqus.net:access-token");
                if (string.IsNullOrEmpty(accessToken))
                {
                    throw new Exception("Environment variable \"disqus.net:access-token\" not found");
                }

                int applicationId;
                if (!int.TryParse(Environment.GetEnvironmentVariable("disqus.net:application-id"), out applicationId))
                {
                    throw new Exception("Environment variable \"disqus.net:application-id\" not found or not number");
                }

                int categoryId;
                if (!int.TryParse(Environment.GetEnvironmentVariable("disqus.net:category-id"), out categoryId))
                {
                    throw new Exception("Environment variable \"disqus.net:category-id\" not found or not number");
                }

                string forumName = Environment.GetEnvironmentVariable("disqus.net:forum");
                if (string.IsNullOrEmpty(forumName))
                {
                    throw new Exception("Environment variable \"disqus.net:forum\" not found");
                }

                int userId;
                if (!int.TryParse(Environment.GetEnvironmentVariable("disqus.net:user-id"), out userId))
                {
                    throw new Exception("Environment variable \"disqus.net:user-id\" not found");
                }

                string userName = Environment.GetEnvironmentVariable("disqus.net:user-name");
                if (string.IsNullOrEmpty(userName))
                {
                    throw new Exception("Environment variable \"disqus.net:user-name\" not found");
                }

                int moderatorUserId;
                if (!int.TryParse(Environment.GetEnvironmentVariable("disqus.net:moderator-id"), out moderatorUserId))
                {
                    throw new Exception("Environment variable \"disqus.net:moderator-id\" not found or not number");
                }

                string moderatorUserName = Environment.GetEnvironmentVariable("disqus.net:moderator-name");
                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new Exception("Environment variable \"disqus.net:moderator-name\" not found");
                }

                int organizationId;
                if (!int.TryParse(Environment.GetEnvironmentVariable("disqus.net:organization-id"), out organizationId))
                {
                    throw new Exception("Environment variable \"disqus.net:organization-id\" not found or not number");
                }

                long postId;
                if (!long.TryParse(Environment.GetEnvironmentVariable("disqus.net:post-id"), out postId))
                {
                    throw new Exception("Environment variable \"disqus.net:post-id\" not found or not number");
                }

                string threadId = Environment.GetEnvironmentVariable("disqus.net:thread-id");
                if (string.IsNullOrEmpty(threadId))
                {
                    throw new Exception("Environment variable \"disqus.net:thread-id\" not found");
                }

                string trustedDomain = Environment.GetEnvironmentVariable("disqus.net:trusted-domain");
                if (string.IsNullOrEmpty(trustedDomain))
                {
                    throw new Exception("Environment variable \"disqus.net:trusted-domain\" not found");
                }

                SecretKey = secretKey;
                AccessToken = accessToken;
                ApplicationId = applicationId;
                CategoryId = categoryId;
                Forum = forumName;
                UserId = userId;
                UserName = userName;
                ModeratorUserId = moderatorUserId;
                ModeratorUserName = moderatorUserName;
                OrganizationId = organizationId;
                PostId = postId;
                ThreadId = threadId;
                TrustedDomain = trustedDomain;
            }
        }

        protected static DisqusTestVariables TestData => new DisqusTestVariables();

        protected IDisqusApi Disqus;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            if (string.IsNullOrWhiteSpace(TestData.SecretKey))
            {
                throw new ArgumentNullException(TestData.SecretKey, "You should explicit specify Disqus Secret Key!");
            }

            if (string.IsNullOrWhiteSpace(TestData.AccessToken))
            {
                throw new ArgumentNullException(TestData.AccessToken, "You should explicit specify Disqus Access Token!");
            }

            Disqus = new DisqusApi(new DisqusRequestProcessor(new DisqusRestClient()), DisqusAuthMethod.SecretKey, TestData.SecretKey);
        }
    }
}
