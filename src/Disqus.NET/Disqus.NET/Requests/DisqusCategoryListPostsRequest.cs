using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusCategoryListPostsRequest : DisqusRequestBase
    {
        private DisqusCategoryListPostsRequest(int categoryId) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("category", categoryId.ToString()));
        }

        public static DisqusCategoryListPostsRequest New(int categoryId)
        {
            return new DisqusCategoryListPostsRequest(categoryId);
        }

        public DisqusCategoryListPostsRequest Since(string timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp));

            return this;
        }

        public DisqusCategoryListPostsRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusCategoryListPostsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusCategoryListPostsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", limit.ToString()));

            return this;
        }

        public DisqusCategoryListPostsRequest Query(string query)
        {
            Parameters.Add(new KeyValuePair<string, string>("query", query));

            return this;
        }

        public DisqusCategoryListPostsRequest Include(DisqusPostInclude include)
        {
            if (include == DisqusPostInclude.None) return this;

            var parameters = include.ToStringArray().Select(r => new KeyValuePair<string, string>("include", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusCategoryListPostsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
