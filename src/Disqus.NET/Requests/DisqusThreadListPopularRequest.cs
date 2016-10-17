using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusThreadListPopularRequest : DisqusRequestBase
    {
        private DisqusThreadListPopularRequest() : base()
        {
        }

        public static DisqusThreadListPopularRequest New()
        {
            return new DisqusThreadListPopularRequest();
        }

        public DisqusThreadListPopularRequest Category(int category)
        {
            Parameters.Add(new KeyValuePair<string, string>("category", category.ToString()));

            return this;
        }

        public DisqusThreadListPopularRequest Interval(DisqusPopularInterval interval)
        {
            Parameters.Add(new KeyValuePair<string, string>("interval", interval.AsParameterValue()));

            return this;
        }

        public DisqusThreadListPopularRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }

        public DisqusThreadListPopularRequest Related(DisqusThreadRelated related)
        {
            if (related == DisqusThreadRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListPopularRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusThreadListPopularRequest WithTopPost(bool withTopPost)
        {
            if (!withTopPost) return this;

            Parameters.Add(new KeyValuePair<string, string>("with_top_post", "1"));

            return this;
        }
    }
}
