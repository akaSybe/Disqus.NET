using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusUserListMostActiveForumsRequest : DisqusRequestBase
    {
        private DisqusUserListMostActiveForumsRequest()
        {    
        }

        public static DisqusUserListMostActiveForumsRequest New()
        {
            return new DisqusUserListMostActiveForumsRequest();
        }

        public DisqusUserListMostActiveForumsRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUserListMostActiveForumsRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUserListMostActiveForumsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }
    }
}
