namespace Disqus.NET
{
    public interface IDisqusApi
    {
        /// <summary>
        /// Ability to change disqus auth configuration
        /// </summary>
        /// <param name="auth"></param>
        void SetDisqusAuth(DisqusAuth auth);
    }
}