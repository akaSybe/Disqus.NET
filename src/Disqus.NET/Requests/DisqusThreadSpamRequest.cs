using System.Collections.Generic;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadSpamRequest : DisqusRequestBase
    {
        private DisqusThreadSpamRequest(DisqusThreadLookupType lookupType, string thread) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
        }

        public static DisqusThreadSpamRequest New(DisqusThreadLookupType lookupType, string thread)
        {
            return new DisqusThreadSpamRequest(lookupType, thread);
        }

        public DisqusThreadSpamRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }
    }
}
