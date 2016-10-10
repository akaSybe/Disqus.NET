using System;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    {
        public IDisqusCategoryApi Category { get; }
        public IDisqusForumCategoryApi ForumCategory { get; }
        public IDisqusForumsApi Forums { get; }
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
            Users = new DisqusUsersApi(requestProcessor, authMethod, key);
        }
    }
}