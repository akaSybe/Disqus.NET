using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusThreadListPostsRequest: DisqusRequestBase
    {
        private DisqusThreadListPostsRequest(DisqusThreadLookupType lookupType, string thread)
        {
            Parameters.Add(new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
        }

        public static DisqusThreadListPostsRequest New(DisqusThreadLookupType lookupType, string thread)
        {
            return new DisqusThreadListPostsRequest(lookupType, thread);
        }

        public DisqusThreadListPostsRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }

        public DisqusThreadListPostsRequest Since(string timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp));

            return this;
        }

        public DisqusThreadListPostsRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListPostsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusThreadListPostsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusThreadListPostsRequest Query(string query)
        {
            Parameters.Add(new KeyValuePair<string, string>("query", query));

            return this;
        }

        public DisqusThreadListPostsRequest Include(DisqusPostInclude include)
        {
            if (include == DisqusPostInclude.None) return this;

            var parameters = include.ToStringArray().Select(r => new KeyValuePair<string, string>("include", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListPostsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
