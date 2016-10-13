using System;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    {
        public IDisqusCategoryApi Category { get; }
        public IDisqusForumCategoryApi ForumCategory { get; }
        public IDisqusForumsApi Forums { get; }
        public IDisqusOrganizationsApi Organizations { get; }
        public IDisqusThreadsApi Threads { get; }
        public IDisqusTrustedDomainsApi TrustedDomains { get; }
        public IDisqusUsersApi Users { get; }

        public DisqusApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            Category = new DisqusCategoryApi(requestProcessor, authMethod, key);
            ForumCategory = new DisqusForumCategoriesApi(requestProcessor, authMethod, key);
            Forums = new DisqusForumsApi(requestProcessor, authMethod, key);
            Organizations = new DisqusOrganizationsApi(requestProcessor, authMethod, key);
            Threads = new DisqusThreadsApi(requestProcessor, authMethod, key);
            TrustedDomains = new DisqusTrustedDomainsApi(requestProcessor, authMethod, key);
            Users = new DisqusUsersApi(requestProcessor, authMethod, key);
        }
    }
}