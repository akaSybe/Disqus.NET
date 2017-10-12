using System;
using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusUserListPostsRequest: DisqusRequestBase
    {
        private DisqusUserListPostsRequest()
        {    
        }

        public static DisqusUserListPostsRequest New()
        {
            return new DisqusUserListPostsRequest();
        }

        public DisqusUserListPostsRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUserListPostsRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUserListPostsRequest Since(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp.ToString("s")));

            return this;
        }

        public DisqusUserListPostsRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusUserListPostsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusUserListPostsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusUserListPostsRequest Include(DisqusPostInclude include)
        {
            if (include == DisqusPostInclude.None) return this;

            var parameters = include.ToStringArray().Select(r => new KeyValuePair<string, string>("include", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusUserListPostsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
