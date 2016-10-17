using System.Collections.Generic;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusUserListActiveForumsRequest : DisqusRequestBase
    {
        private DisqusUserListActiveForumsRequest()
        {    
        }

        public static DisqusUserListActiveForumsRequest New()
        {
            return new DisqusUserListActiveForumsRequest();
        }

        public DisqusUserListActiveForumsRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUserListActiveForumsRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUserListActiveForumsRequest SinceId(string sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId));

            return this;
        }

        public DisqusUserListActiveForumsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusUserListActiveForumsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusUserListActiveForumsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
