using System.Collections.Generic;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusUserListFollowersRequest : DisqusRequestBase
    {
        private DisqusUserListFollowersRequest()
        {    
        }

        public static DisqusUserListFollowersRequest New()
        {
            return new DisqusUserListFollowersRequest();
        }

        public DisqusUserListFollowersRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUserListFollowersRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUserListFollowersRequest SinceId(string sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId));

            return this;
        }

        public DisqusUserListFollowersRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusUserListFollowersRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusUserListFollowersRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
