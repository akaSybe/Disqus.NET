using System.Collections.Generic;
using System.Linq;

namespace Disqus.NET.Requests
{
    public class DisqusBlacklistRemoveRequest : DisqusRequestBase
    {
        private DisqusBlacklistRemoveRequest(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusBlacklistRemoveRequest New(string forum)
        {
            return new DisqusBlacklistRemoveRequest(forum);
        }

        public DisqusBlacklistRemoveRequest Domain(params string[] domains)
        {
            var parameters = domains.Select(domain => new KeyValuePair<string, string>("domain", domain));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistRemoveRequest Word(params string[] words)
        {
            var parameters = words.Select(word => new KeyValuePair<string, string>("word", word));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistRemoveRequest IpAddress(params string[] ipAddresses)
        {
            var parameters = ipAddresses.Select(ipAddress => new KeyValuePair<string, string>("ip", ipAddress));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistRemoveRequest User(params int[] users)
        {
            var parameters = users.Select(user => new KeyValuePair<string, string>("user", user.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistRemoveRequest User(params string[] usernames)
        {
            var parameters = usernames.Select(username => new KeyValuePair<string, string>("user:username", username));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistRemoveRequest Email(params string[] emails)
        {
            var parameters = emails.Select(email => new KeyValuePair<string, string>("email", email));
            Parameters.AddRange(parameters);

            return this;
        }
    }
}
