using System;
using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusForumListPostsRequest : DisqusRequestBase
    {
        private DisqusForumListPostsRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumListPostsRequest New(string forum)
        {
            return new DisqusForumListPostsRequest(forum);
        }

        public DisqusForumListPostsRequest Since(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp.ToString("s")));

            return this;
        }

        public DisqusForumListPostsRequest Related(DisqusForumListPostsRelated related)
        {
            if (related == DisqusForumListPostsRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusForumListPostsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusForumListPostsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusForumListPostsRequest Query(string query)
        {
            Parameters.Add(new KeyValuePair<string, string>("query", query));

            return this;
        }

        public DisqusForumListPostsRequest Include(DisqusPostInclude include)
        {
            if (include == DisqusPostInclude.None) return this;

            var parameters = include.ToStringArray().Select(r => new KeyValuePair<string, string>("include", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusForumListPostsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
