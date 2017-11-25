using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusUserListForumsRequest : DisqusRequestBase
    {
        private DisqusUserListForumsRequest()
        {    
        }

        public static DisqusUserListForumsRequest New()
        {
            return new DisqusUserListForumsRequest();
        }

        public DisqusUserListForumsRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUserListForumsRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUserListForumsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusUserListForumsRequest SinceId(string sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId));

            return this;
        }

        public DisqusUserListForumsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusUserListForumsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
