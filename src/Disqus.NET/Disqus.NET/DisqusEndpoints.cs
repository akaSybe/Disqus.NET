namespace Disqus.NET
{
    /// <summary>
    /// Endpoints for Disqus API 3.0
    /// </summary>
    public class DisqusEndpoints
    {
        private const string ApiUrl = "https://disqus.com/api/3.0/";
        private const string OutputType = ".json";

        private static string GetUrl(string category, string resource)
        {
            return ApiUrl + category + "/" + resource + OutputType;
        }

        public static class Categories
        {
            private const string Category = "categories";

            public static string Create = GetUrl(Category, "create");
            public static string Details = GetUrl(Category, "details");
            public static string List = GetUrl(Category, "list");
        }

        public static class Forums
        {
            private const string Category = "forums";

            public static string Details = GetUrl(Category, "details");
        }

        public static class Users
        {
            private const string Category = "users";

            public static string Details = GetUrl(Category, "details");
            public static string Follow = GetUrl(Category, "follow");
            public static string Unfollow = GetUrl(Category, "unfollow");
            public static string UpdateProfile = GetUrl(Category, "updateProfile");
        }

        public static class Posts
        {
            private const string Category = "posts";

            public static string Details = GetUrl(Category, "details");
        }
    }
}
