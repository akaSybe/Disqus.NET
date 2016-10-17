using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusThreadDetailsRequest : DisqusRequestBase
    {
        private DisqusThreadDetailsRequest(DisqusThreadLookupType lookupType, string thread) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
        }

        public static DisqusThreadDetailsRequest New(DisqusThreadLookupType lookupType, string thread)
        {
            return new DisqusThreadDetailsRequest(lookupType, thread);
        }

        public DisqusThreadDetailsRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }

        public DisqusThreadDetailsRequest Related(DisqusThreadRelated related)
        {
            if (related == DisqusThreadRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadDetailsRequest Attach(DisqusThreadAttach attach)
        {
            if (attach == DisqusThreadAttach.None) return this;

            var parameters = attach.ToStringArray().Select(a => new KeyValuePair<string, string>("attach", a));
            Parameters.AddRange(parameters);

            return this;
        }
    }
}
