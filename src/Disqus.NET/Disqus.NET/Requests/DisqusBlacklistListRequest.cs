using System;
using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusBlacklistListRequest : DisqusRequestBase
    {
        private DisqusBlacklistListRequest(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusBlacklistListRequest New(string forum)
        {
            return new DisqusBlacklistListRequest(forum);
        }

        public DisqusBlacklistListRequest Since(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp.ToString("s")));

            return this;
        }

        public DisqusBlacklistListRequest Related(DisqusBlacklistEntryRelated related)
        {
            if (related == DisqusBlacklistEntryRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistListRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusBlacklistListRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusBlacklistListRequest SinceId(int id)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", id.ToString()));

            return this;
        }

        public DisqusBlacklistListRequest Query(string query)
        {
            Parameters.Add(new KeyValuePair<string, string>("query", query));

            return this;
        }

        public DisqusBlacklistListRequest Type(DisqusBlacklistEntryTypes type)
        {
            if (type == DisqusBlacklistEntryTypes.None) return this;

            var parameters = type.ToStringArray().Select(r => new KeyValuePair<string, string>("type", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistListRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
