using System.Collections.Generic;
using System.Linq;

namespace Disqus.NET.Requests
{
    public class DisqusWhitelistAddRequest: DisqusRequestBase
    {
        private DisqusWhitelistAddRequest(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusWhitelistAddRequest New(string forum)
        {
            return new DisqusWhitelistAddRequest(forum);
        }

        public DisqusWhitelistAddRequest Notes(string notes)
        {
            Parameters.Add(new KeyValuePair<string, string>("notes", notes));

            return this;
        }

        public DisqusWhitelistAddRequest Email(params string[] emails)
        {
            var parameters = emails.Select(email => new KeyValuePair<string, string>("email", email));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusWhitelistAddRequest User(params int[] users)
        {
            var parameters = users.Select(user => new KeyValuePair<string, string>("user", user.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusWhitelistAddRequest User(params string[] usernames)
        {
            var parameters = usernames.Select(username => new KeyValuePair<string, string>("user:username", username));
            Parameters.AddRange(parameters);

            return this;
        }
    }
}
