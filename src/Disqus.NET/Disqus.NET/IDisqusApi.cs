namespace Disqus.NET
{
    public interface IDisqusApi
    {
        IDisqusCategoryApi Category { get; }
        IDisqusForumCategoryApi ForumCategory { get; }
        IDisqusForumsApi Forums { get; }
        IDisqusOrganizationsApi Organizations { get; }
        IDisqusPostsApi Posts { get; }
        IDisqusThreadsApi Threads { get; }
        IDisqusTrustedDomainsApi TrustedDomains { get; }
        IDisqusUsersApi Users { get; }
    }
}