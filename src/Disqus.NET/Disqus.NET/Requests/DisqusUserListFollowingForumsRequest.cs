using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusUserListFollowingForumsRequest : DisqusRequestBase
    {
        private DisqusUserListFollowingForumsRequest()
        {    
        }

        public static DisqusUserListFollowingForumsRequest New()
        {
            return new DisqusUserListFollowingForumsRequest();
        }

        public DisqusUserListFollowingForumsRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUserListFollowingForumsRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUserListFollowingForumsRequest SinceId(string sinceId)
        {
            Parameters.Add(new KeyValuePair<string, string>("since_id", sinceId));

            return this;
        }

        public DisqusUserListFollowingForumsRequest Attach(DisqusPostInclude include)
        {
            if (include == DisqusPostInclude.None) return this;

            var parameters = include.ToStringArray().Select(i => new KeyValuePair<string, string>("include", i));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusUserListFollowingForumsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusUserListFollowingForumsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusUserListFollowingForumsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
