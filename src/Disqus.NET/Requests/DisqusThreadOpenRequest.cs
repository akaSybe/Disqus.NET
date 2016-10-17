using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadOpenRequest : DisqusRequestBase
    {
        private DisqusThreadOpenRequest(DisqusThreadLookupType lookupType, params string[] threads) : base()
        {
            var parameters = threads.Select(thread => new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.AddRange(parameters);
        }

        public static DisqusThreadOpenRequest New(DisqusThreadLookupType lookupType, params string[] threads)
        {
            return new DisqusThreadOpenRequest(lookupType, threads);
        }

        public DisqusThreadOpenRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }
    }
}
