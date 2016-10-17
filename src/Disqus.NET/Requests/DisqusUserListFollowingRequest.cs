using System.Collections.Generic;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusUserListFollowingRequest : DisqusRequestBase
    {
        private DisqusUserListFollowingRequest()
        {    
        }

        public static DisqusUserListFollowingRequest New()
        {
            return new DisqusUserListFollowingRequest();
        }

        public DisqusUserListFollowingRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUserListFollowingRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUserListFollowingRequest SinceId(string sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId));

            return this;
        }

        public DisqusUserListFollowingRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusUserListFollowingRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusUserListFollowingRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
