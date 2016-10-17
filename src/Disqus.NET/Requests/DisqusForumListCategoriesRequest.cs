using System.Collections.Generic;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusForumListCategoriesRequest : DisqusRequestBase
    {
        private DisqusForumListCategoriesRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumListCategoriesRequest New(string forum)
        {
            return new DisqusForumListCategoriesRequest(forum);
        }

        public DisqusForumListCategoriesRequest SinceId(int sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId.ToString()));

            return this;
        }

        public DisqusForumListCategoriesRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusForumListCategoriesRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusForumListCategoriesRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
