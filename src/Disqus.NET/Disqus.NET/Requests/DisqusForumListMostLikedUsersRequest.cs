using System.Collections.Generic;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusForumListMostLikedUsersRequest : DisqusRequestBase
    {
        private DisqusForumListMostLikedUsersRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumListMostLikedUsersRequest New(string forum)
        {
            return new DisqusForumListMostLikedUsersRequest(forum);
        }

        public DisqusForumListMostLikedUsersRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusForumListMostLikedUsersRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusForumListMostLikedUsersRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
