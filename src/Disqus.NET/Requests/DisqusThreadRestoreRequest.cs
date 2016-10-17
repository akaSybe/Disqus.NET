using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadRestoreRequest : DisqusRequestBase
    {
        private DisqusThreadRestoreRequest(DisqusThreadLookupType lookupType, params string[] threads) : base()
        {
            var parameters = threads.Select(thread => new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.AddRange(parameters);
        }

        public static DisqusThreadRestoreRequest New(DisqusThreadLookupType lookupType, params string[] threads)
        {
            return new DisqusThreadRestoreRequest(lookupType, threads);
        }

        public DisqusThreadRestoreRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }
    }
}
