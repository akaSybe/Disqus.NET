using System.Collections.Generic;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusForumListFollowersRequest : DisqusRequestBase
    {
        private DisqusForumListFollowersRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumListFollowersRequest New(string forum)
        {
            return new DisqusForumListFollowersRequest(forum);
        }

        public DisqusForumListFollowersRequest SinceId(int sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId.ToString()));

            return this;
        }

        public DisqusForumListFollowersRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusForumListFollowersRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusForumListFollowersRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
