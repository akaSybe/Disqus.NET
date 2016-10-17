using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadCloseRequest : DisqusRequestBase
    {
        private DisqusThreadCloseRequest(DisqusThreadLookupType lookupType, params string[] threads) : base()
        {
            var parameters = threads.Select(thread => new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.AddRange(parameters);
        }

        public static DisqusThreadCloseRequest New(DisqusThreadLookupType lookupType, params string[] threads)
        {
            return new DisqusThreadCloseRequest(lookupType, threads);
        }

        public DisqusThreadCloseRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }
    }
}
