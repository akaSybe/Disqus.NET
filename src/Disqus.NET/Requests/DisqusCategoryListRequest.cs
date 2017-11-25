using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusCategoryListRequest : DisqusRequestBase
    {
        private DisqusCategoryListRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusCategoryListRequest New(string forum)
        {
            return new DisqusCategoryListRequest(forum);
        }

        public DisqusCategoryListRequest SinceId(int sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId.ToString()));

            return this;
        }

        public DisqusCategoryListRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusCategoryListRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusCategoryListRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
