namespace Disqus.NET
{
    public interface IDisqusApi
    {
        IDisqusCategoryApi Category { get; }
        IDisqusForumCategoryApi ForumCategory { get; }
        IDisqusForumsApi Forums { get; }
        IDisqusUsersApi Users { get; }
    }
}