using System;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    {
        public IDisqusApplicationsApi Applications { get; }
        public IDisqusBlacklistsApi Blacklists { get; }
        public IDisqusCategoryApi Category { get; }
        public IDisqusForumCategoryApi ForumCategory { get; }
        public IDisqusForumsApi Forums { get; }
        public IDisqusImportsApi Imports { get; }
        public IDisqusOrganizationsApi Organizations { get; }
        public IDisqusPostsApi Posts { get; }
        public IDisqusThreadsApi Threads { get; }
        public IDisqusTrustedDomainsApi TrustedDomains { get; }
        public IDisqusUsersApi Users { get; }
        public IDisqusWhitelistsApi Whitelists { get; set; }

        public DisqusApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            Applications = new DisqusApplicationsApi(requestProcessor, authMethod, key);
            Blacklists = new DisqusBlacklistsApi(requestProcessor, authMethod, key);
            Category = new DisqusCategoryApi(requestProcessor, authMethod, key);
            ForumCategory = new DisqusForumCategoriesApi(requestProcessor, authMethod, key);
            Forums = new DisqusForumsApi(requestProcessor, authMethod, key);
            Imports = new DisqusImportsApi(requestProcessor, authMethod, key);
            Organizations = new DisqusOrganizationsApi(requestProcessor, authMethod, key);
            Posts = new DisqusPostsApi(requestProcessor, authMethod, key);
            Threads = new DisqusThreadsApi(requestProcessor, authMethod, key);
            TrustedDomains = new DisqusTrustedDomainsApi(requestProcessor, authMethod, key);
            Users = new DisqusUsersApi(requestProcessor, authMethod, key);
            Whitelists = new DisqusWhitelistsApi(requestProcessor, authMethod, key);
        }
    }
}