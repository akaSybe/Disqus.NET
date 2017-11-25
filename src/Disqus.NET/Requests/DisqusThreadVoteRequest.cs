using System.Collections.Generic;

using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadVoteRequest : DisqusRequestBase
    {
        private DisqusThreadVoteRequest(DisqusThreadLookupType lookupType, string thread, DisqusVote vote) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.Add(new KeyValuePair<string, string>("vote", vote.ToString("D")));
        }

        public static DisqusThreadVoteRequest New(DisqusThreadLookupType lookupType, string thread, DisqusVote vote)
        {
            return new DisqusThreadVoteRequest(lookupType, thread, vote);
        }

        public DisqusThreadVoteRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }
    }
}
