using System.Collections.Generic;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadApproveRequest : DisqusRequestBase
    {
        private DisqusThreadApproveRequest(DisqusThreadLookupType lookupType, string thread) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
        }

        public static DisqusThreadApproveRequest New(DisqusThreadLookupType lookupType, string thread)
        {
            return new DisqusThreadApproveRequest(lookupType, thread);
        }

        public DisqusThreadApproveRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }
    }
}
