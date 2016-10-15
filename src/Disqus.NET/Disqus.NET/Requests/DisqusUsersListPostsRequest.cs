using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusUsersListPostsRequest: DisqusRequestBase
    {
        private DisqusUsersListPostsRequest()
        {    
        }

        public static DisqusUsersListPostsRequest New()
        {
            return new DisqusUsersListPostsRequest();
        }

        public DisqusUsersListPostsRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUsersListPostsRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUsersListPostsRequest Since(string timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp));

            return this;
        }

        public DisqusUsersListPostsRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusUsersListPostsRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusUsersListPostsRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", limit.ToString()));

            return this;
        }

        public DisqusUsersListPostsRequest Include(DisqusPostInclude include)
        {
            if (include == DisqusPostInclude.None) return this;

            var parameters = include.ToStringArray().Select(r => new KeyValuePair<string, string>("include", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusUsersListPostsRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
