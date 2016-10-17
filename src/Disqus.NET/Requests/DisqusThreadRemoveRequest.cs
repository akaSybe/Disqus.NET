using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadRemoveRequest : DisqusRequestBase
    {
        private DisqusThreadRemoveRequest(DisqusThreadLookupType lookupType, params string[] threads) : base()
        {
            var parameters = threads.Select(thread => new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.AddRange(parameters);
        }

        public static DisqusThreadRemoveRequest New(DisqusThreadLookupType lookupType, params string[] threads)
        {
            return new DisqusThreadRemoveRequest(lookupType, threads);
        }

        public DisqusThreadRemoveRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }
    }
}
