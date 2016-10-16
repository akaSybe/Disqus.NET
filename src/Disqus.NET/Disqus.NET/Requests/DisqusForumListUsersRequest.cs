using System.Collections.Generic;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusForumListUsersRequest : DisqusRequestBase
    {
        private DisqusForumListUsersRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumListUsersRequest New(string forum)
        {
            return new DisqusForumListUsersRequest(forum);
        }

        public DisqusForumListUsersRequest SinceId(int sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId.ToString()));

            return this;
        }

        public DisqusForumListUsersRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusForumListUsersRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusForumListUsersRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
