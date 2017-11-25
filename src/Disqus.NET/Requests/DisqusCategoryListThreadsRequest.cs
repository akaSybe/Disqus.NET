using System;
using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusCategoryListThreadsRequest : DisqusRequestBase
    {
        private DisqusCategoryListThreadsRequest(int categoryId) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("category", categoryId.ToString()));
        }

        public static DisqusCategoryListThreadsRequest New(int categoryId)
        {
            return new DisqusCategoryListThreadsRequest(categoryId);
        }

        public DisqusCategoryListThreadsRequest Since(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp.ToString("s")));

            return this;
        }

        public DisqusCategoryListThreadsRequest Related(DisqusCategoryListThreadRelated related)
        {
            if (related == DisqusCategoryListThreadRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusCategoryListThreadsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusCategoryListThreadsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusCategoryListThreadsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
