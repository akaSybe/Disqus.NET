using System;
using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusWhitelistListRequest : DisqusRequestBase
    {
        private DisqusWhitelistListRequest(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusWhitelistListRequest New(string forum)
        {
            return new DisqusWhitelistListRequest(forum);
        }

        public DisqusWhitelistListRequest Since(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp.ToString("s")));

            return this;
        }

        public DisqusWhitelistListRequest Related(DisqusWhitelistEntryRelated related)
        {
            if (related == DisqusWhitelistEntryRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusWhitelistListRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusWhitelistListRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusWhitelistListRequest SinceId(int id)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", id.ToString()));

            return this;
        }

        public DisqusWhitelistListRequest Query(string query)
        {
            Parameters.Add(new KeyValuePair<string, string>("query", query));

            return this;
        }

        public DisqusWhitelistListRequest Type(DisqusWhitelistEntryTypes type)
        {
            if (type == DisqusWhitelistEntryTypes.None) return this;

            var parameters = type.ToStringArray().Select(r => new KeyValuePair<string, string>("type", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusWhitelistListRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
