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

        public static class ForumCategories
        {
            private const string Category = "forumCategories";

            public static string Details = GetUrl(Category, "details");
            public static string List = GetUrl(Category, "list");
        }

        public static class Forums
        {
            private const string Category = "forums";

            public static string AddModerator = GetUrl(Category, "addModerator");
            public static string Create = GetUrl(Category, "create");
            public static string Details = GetUrl(Category, "details");
            public static string DisableAds = GetUrl(Category, "disableAds");
            public static string FixFavIconsForClassifiedForums = GetUrl(Category, "fixFavIconsForClassifiedForums");
            public static string Follow = GetUrl(Category, "follow");
            public static string GenerateInterestingContent = GetUrl(Category, "generateInterestingContent");
            public static string InterestingForums = GetUrl(Category, "interestingForums");
            public static string ListCategories = GetUrl(Category, "listCategories");
            public static string ListFollowers = GetUrl(Category, "listFollowers");
            public static string ListModerators = GetUrl(Category, "listModerators");
            public static string ListMostActiveUsers = GetUrl(Category, "listMostActiveUsers");
            public static string ListMostLikedUsers = GetUrl(Category, "listMostLikedUsers");
            public static string ListPosts = GetUrl(Category, "listPosts");
            public static string ListThreads = GetUrl(Category, "listThreads");
            public static string ListUsers = GetUrl(Category, "listUsers");
            public static string RemoveDefaultAvatar = GetUrl(Category, "removeDefaultAvatar");
            public static string RemoveModerator = GetUrl(Category, "removeModerator");
            public static string Unfollow = GetUrl(Category, "unfollow");
            public static string Update = GetUrl(Category, "update");
            public static string UpdateDefaultAvatar = GetUrl(Category, "updateDefaultAvatar");
            public static string Validate = GetUrl(Category, "validate");
        }

        public static class Users
        {
            private const string Category = "users";

            public static string CheckUsername = GetUrl(Category, "checkUsername");
            public static string Details = GetUrl(Category, "details");
            public static string Follow = GetUrl(Category, "follow");
            public static string InterestingUsers = GetUrl(Category, "interestingUsers");
            public static string ListActiveForums = GetUrl(Category, "listActiveForums");
            public static string ListActivity = GetUrl(Category, "listActivity");
            public static string ListFollowers = GetUrl(Category, "listFollowers");
            public static string ListFollowing = GetUrl(Category, "listFollowing");
            public static string ListFollowingChannels = GetUrl(Category, "listFollowingChannels");
            public static string ListFollowingForums = GetUrl(Category, "listFollowingForums");
            public static string ListForums = GetUrl(Category, "listForums");
            public static string ListModeratedChannels = GetUrl(Category, "listModeratedChannels");
            public static string ListMostActiveForums = GetUrl(Category, "listMostActiveForums");
            public static string ListOwnedChannels = GetUrl(Category, "listOwnedChannels");
            public static string ListPosts = GetUrl(Category, "listPosts");
            public static string RemoveFollower = GetUrl(Category, "removeFollower");
            public static string Report = GetUrl(Category, "report");
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
