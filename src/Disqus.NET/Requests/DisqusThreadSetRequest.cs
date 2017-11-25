using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadSetRequest : DisqusRequestBase
    {
        private DisqusThreadSetRequest(DisqusThreadLookupType lookupType, params string[] threads) : base()
        {
            var parameters = threads.Select(thread => new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.AddRange(parameters);
        }

        public static DisqusThreadSetRequest New(DisqusThreadLookupType lookupType, params string[] forums)
        {
            return new DisqusThreadSetRequest(lookupType, forums);
        }

        public DisqusThreadSetRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }

        public DisqusThreadSetRequest ByThreads(DisqusThreadLookupType lookupType, params string[] threads)
        {
            var parameters = threads.Select(thread => new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadSetRequest Related(DisqusThreadRelated related)
        {
            if (related == DisqusThreadRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadSetRequest Attach(DisqusThreadAttach attach)
        {
            if (attach == DisqusThreadAttach.None) return this;

            var parameters = attach.ToStringArray().Select(a => new KeyValuePair<string, string>("attach", a));
            Parameters.AddRange(parameters);

            return this;
        }
    }
}
