namespace Disqus.NET
{
    public interface IDisqusApi
    {
        IDisqusCategoryApi Category { get; }
        IDisqusForumCategoryApi ForumCategory { get; }
        IDisqusForumsApi Forums { get; }
        IDisqusOrganizationsApi Organizations { get; }
        IDisqusThreadsApi Threads { get; }
        IDisqusTrustedDomainsApi TrustedDomains { get; }
        IDisqusUsersApi Users { get; }
    }
}