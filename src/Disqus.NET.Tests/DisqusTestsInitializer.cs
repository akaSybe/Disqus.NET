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

            private const string DisqusNetSecretKeyVariable = "disqus.net:secret-key";
            private const string DisqusNetAccessTokenVariable = "disqus.net:access-token";
            private const string DisqusNetForumNameVariable = "disqus.net:forum";
            private const string DisqusNetUserIdVariable = "disqus.net:user-id";
            private const string DisqusNetUserNameVariable = "disqus.net:user-name";
            private const string DisqusNetModeratorUserIdVariable = "disqus.net:moderator-id";
            private const string DisqusNetModeratorUserNameVariable = "disqus.net:moderator-name";
            private const string DisqusNetThreadIdVariable = "disqus.net:thread-id";
            private const string DisqusNetPostIdVariable = "disqus.net:post-id";
            private const string DisqusNetCategoryIdVariable = "disqus.net:category-id";
            private const string DisqusNetApplicationIdVariable = "disqus.net:application-id";
            private const string DisqusNetTrustedDomainVariable = "disqus.net:trusted-domain";
            private const string DisqusNetOrganizationIdVariable = "disqus.net:organization-id";

            public DisqusTestVariables()
            {
                string secretKey = Environment.GetEnvironmentVariable(DisqusNetSecretKeyVariable);
                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new Exception($"Environment variable \"{DisqusNetSecretKeyVariable}\" not found");
                }

                string accessToken = Environment.GetEnvironmentVariable(DisqusNetAccessTokenVariable);
                if (string.IsNullOrEmpty(accessToken))
                {
                    throw new Exception($"Environment variable \"{DisqusNetAccessTokenVariable}\" not found");
                }

                int applicationId;
                if (!int.TryParse(Environment.GetEnvironmentVariable(DisqusNetApplicationIdVariable), out applicationId))
                {
                    throw new Exception($"Environment variable \"{DisqusNetApplicationIdVariable}\" not found or not number");
                }

                int categoryId;
                if (!int.TryParse(Environment.GetEnvironmentVariable(DisqusNetCategoryIdVariable), out categoryId))
                {
                    throw new Exception($"Environment variable \"{DisqusNetCategoryIdVariable}\" not found or not number");
                }

                string forumName = Environment.GetEnvironmentVariable(DisqusNetForumNameVariable);
                if (string.IsNullOrEmpty(forumName))
                {
                    throw new Exception($"Environment variable \"{DisqusNetForumNameVariable}\" not found");
                }

                int userId;
                if (!int.TryParse(Environment.GetEnvironmentVariable(DisqusNetUserIdVariable), out userId))
                {
                    throw new Exception($"Environment variable \"{DisqusNetUserIdVariable}\" not found");
                }

                string userName = Environment.GetEnvironmentVariable(DisqusNetUserNameVariable);
                if (string.IsNullOrEmpty(userName))
                {
                    throw new Exception($"Environment variable \"{DisqusNetUserNameVariable}\" not found");
                }

                int moderatorUserId;
                if (!int.TryParse(Environment.GetEnvironmentVariable(DisqusNetModeratorUserIdVariable), out moderatorUserId))
                {
                    throw new Exception($"Environment variable \"{DisqusNetModeratorUserIdVariable}\" not found or not number");
                }

                string moderatorUserName = Environment.GetEnvironmentVariable(DisqusNetModeratorUserNameVariable);
                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new Exception($"Environment variable \"{DisqusNetModeratorUserNameVariable}\" not found");
                }

                int organizationId;
                if (!int.TryParse(Environment.GetEnvironmentVariable(DisqusNetOrganizationIdVariable), out organizationId))
                {
                    throw new Exception($"Environment variable \"{DisqusNetOrganizationIdVariable}\" not found or not number");
                }

                long postId;
                if (!long.TryParse(Environment.GetEnvironmentVariable(DisqusNetPostIdVariable), out postId))
                {
                    throw new Exception($"Environment variable \"{DisqusNetPostIdVariable}\" not found or not number");
                }

                string threadId = Environment.GetEnvironmentVariable(DisqusNetThreadIdVariable);
                if (string.IsNullOrEmpty(threadId))
                {
                    throw new Exception($"Environment variable \"{DisqusNetThreadIdVariable}\" not found");
                }

                string trustedDomain = Environment.GetEnvironmentVariable(DisqusNetTrustedDomainVariable);
                if (string.IsNullOrEmpty(trustedDomain))
                {
                    throw new Exception($"Environment variable \"{DisqusNetTrustedDomainVariable}\" not found");
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
