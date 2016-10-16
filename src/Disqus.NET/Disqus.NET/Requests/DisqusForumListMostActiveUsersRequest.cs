using System.Collections.Generic;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusForumListMostActiveUsersRequest : DisqusRequestBase
    {
        private DisqusForumListMostActiveUsersRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumListMostActiveUsersRequest New(string forum)
        {
            return new DisqusForumListMostActiveUsersRequest(forum);
        }

        public DisqusForumListMostActiveUsersRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusForumListMostActiveUsersRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusForumListMostActiveUsersRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
