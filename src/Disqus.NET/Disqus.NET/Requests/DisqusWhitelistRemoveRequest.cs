using System.Collections.Generic;
using System.Linq;

namespace Disqus.NET.Requests
{
    public class DisqusWhitelistRemoveRequest: DisqusRequestBase
    {
        private DisqusWhitelistRemoveRequest(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusWhitelistRemoveRequest New(string forum)
        {
            return new DisqusWhitelistRemoveRequest(forum);
        }

        public DisqusWhitelistRemoveRequest Email(params string[] emails)
        {
            var parameters = emails.Select(email => new KeyValuePair<string, string>("email", email));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusWhitelistRemoveRequest User(params int[] users)
        {
            var parameters = users.Select(user => new KeyValuePair<string, string>("user", user.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusWhitelistRemoveRequest User(params string[] usernames)
        {
            var parameters = usernames.Select(username => new KeyValuePair<string, string>("user:username", username));
            Parameters.AddRange(parameters);

            return this;
        }
    }
}
