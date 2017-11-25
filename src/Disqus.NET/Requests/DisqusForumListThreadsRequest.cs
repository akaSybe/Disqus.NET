using System;
using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusForumListThreadsRequest : DisqusRequestBase
    {
        private DisqusForumListThreadsRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumListThreadsRequest New(string forum)
        {
            return new DisqusForumListThreadsRequest(forum);
        }

        public DisqusForumListThreadsRequest Thread(DisqusThreadLookupType lookupType, params string[] threads)
        {
           var parameters = threads.Select(thread => new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusForumListThreadsRequest Since(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp.ToString("s")));

            return this;
        }

        public DisqusForumListThreadsRequest Related(DisqusCategoryListThreadRelated related)
        {
            if (related == DisqusCategoryListThreadRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusForumListThreadsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusForumListThreadsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusForumListThreadsRequest Include(DisqusThreadInclude include)
        {
            if (include == DisqusThreadInclude.None) return this;

            var parameters = include.ToStringArray().Select(i => new KeyValuePair<string, string>("include", i));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusForumListThreadsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
