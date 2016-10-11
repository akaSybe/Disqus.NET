namespace Disqus.NET
{
    public interface IDisqusApi
    {
        IDisqusCategoryApi Category { get; }
        IDisqusForumCategoryApi ForumCategory { get; }
        IDisqusForumsApi Forums { get; }
        IDisqusOrganizationsApi Organizations { get; }
        IDisqusTrustedDomainsApi TrustedDomains { get; }
        IDisqusUsersApi Users { get; }
    }
}