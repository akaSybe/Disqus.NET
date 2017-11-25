using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusTrendListThreadsRequest: DisqusRequestBase
    {
        private DisqusTrendListThreadsRequest()
        {
        }

        public static DisqusTrendListThreadsRequest New()
        {
            return new DisqusTrendListThreadsRequest();
        }

        public DisqusTrendListThreadsRequest Forum(params string[] forums)
        {
            var parameters = forums.Select(forum => new KeyValuePair<string, string>("forum", forum));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusTrendListThreadsRequest Related(DisqusThreadRelated related)
        {
            if (related == DisqusThreadRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusTrendListThreadsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }
    }
}
