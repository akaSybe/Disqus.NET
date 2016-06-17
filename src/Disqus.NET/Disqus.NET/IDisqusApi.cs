namespace Disqus.NET
{
    public interface IDisqusApi: IDisqusUsersApi, IDisqusPostsApi
    {
        /// <summary>
        /// Ability to change disqus auth configuration
        /// </summary>
        /// <param name="authMethod">Authentication Method</param>
        /// <param name="key">Public or secret key depending on <param name="authMethod">authentication method</param></param>
        void SetDisqusAuth(DisqusAuthMethod authMethod, string key);
    }
}