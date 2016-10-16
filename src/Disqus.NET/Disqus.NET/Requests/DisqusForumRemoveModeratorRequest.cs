using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusForumRemoveModeratorRequest : DisqusRequestBase
    {
        private DisqusForumRemoveModeratorRequest() : base()
        {
        }

        public static DisqusForumRemoveModeratorRequest New()
        {
            return new DisqusForumRemoveModeratorRequest();
        }

        public DisqusForumRemoveModeratorRequest Moderator(int moderatorId)
        {
            Parameters.Add(new KeyValuePair<string, string>("moderator", moderatorId.ToString()));

            return this;
        }

        public DisqusForumRemoveModeratorRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusForumRemoveModeratorRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusForumRemoveModeratorRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }
    }
}
