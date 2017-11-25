using System;
using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusUserListActivityRequest: DisqusRequestBase
    {
        private DisqusUserListActivityRequest()
        {
        }

        public static DisqusUserListActivityRequest New()
        {
            return new DisqusUserListActivityRequest();
        }

        public DisqusUserListActivityRequest User(string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));

            return this;
        }

        public DisqusUserListActivityRequest User(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));

            return this;
        }

        public DisqusUserListActivityRequest Since(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp.ToString("s")));

            return this;
        }

        public DisqusUserListActivityRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusUserListActivityRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusUserListActivityRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusUserListActivityRequest Query(string query)
        {
            Parameters.Add(new KeyValuePair<string, string>("query", query));

            return this;
        }

        public DisqusUserListActivityRequest Include(DisqusUserActivityInclude include)
        {
            if (include == DisqusUserActivityInclude.None) return this;

            var parameters = include.ToStringArray().Select(i => new KeyValuePair<string, string>("include", i));
            Parameters.AddRange(parameters);

            return this;
        }

        /// <summary>
        /// Looks up an anonymous user by unique hash
        /// </summary>
        /// <param name="anonymousUser"></param>
        /// <returns></returns>
        public DisqusUserListActivityRequest AnonymousUser(string anonymousUser)
        {
            Parameters.Add(new KeyValuePair<string, string>("anon_user", anonymousUser));

            return this;
        }
    }
}
