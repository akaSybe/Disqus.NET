using System.Collections.Generic;

using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadListUsersVotedThreadRequest : DisqusRequestBase
    {
        private DisqusThreadListUsersVotedThreadRequest(DisqusThreadLookupType lookupType, string thread) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
        }

        public static DisqusThreadListUsersVotedThreadRequest New(DisqusThreadLookupType lookupType, string thread)
        {
            return new DisqusThreadListUsersVotedThreadRequest(lookupType, thread);
        }

        public DisqusThreadListUsersVotedThreadRequest PrioritizeFollowed(bool prioritizeFollowed)
        {
            Parameters.Add(new KeyValuePair<string, string>("prioritize_followed", prioritizeFollowed ? "1" : "0"));

            return this;
        }

        public DisqusThreadListUsersVotedThreadRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusThreadListUsersVotedThreadRequest Vote(DisqusVote vote)
        {
            Parameters.Add(new KeyValuePair<string, string>("vote", ((int)vote).ToString()));

            return this;
        }
    }
}
