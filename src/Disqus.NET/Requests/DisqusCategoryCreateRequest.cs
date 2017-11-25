using System.Collections.Generic;
using System.Linq;

namespace Disqus.NET.Requests
{
    public class DisqusBlacklistAddRequest : DisqusRequestBase
    {
        private DisqusBlacklistAddRequest(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusBlacklistAddRequest New(string forum)
        {
            return new DisqusBlacklistAddRequest(forum);
        }

        public DisqusBlacklistAddRequest Domain(params string[] domains)
        {
            var parameters = domains.Select(domain => new KeyValuePair<string, string>("domain", domain));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistAddRequest Word(params string[] words)
        {
            var parameters = words.Select(word => new KeyValuePair<string, string>("word", word));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistAddRequest Notes(string notes)
        {
            Parameters.Add(new KeyValuePair<string, string>("notes", notes));

            return this;
        }

        public DisqusBlacklistAddRequest IpAddress(params string[] ipAddresses)
        {
            var parameters = ipAddresses.Select(ipAddress => new KeyValuePair<string, string>("ip", ipAddress));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistAddRequest User(params int[] users)
        {
            var parameters = users.Select(user => new KeyValuePair<string, string>("user", user.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistAddRequest User(params string[] usernames)
        {
            var parameters = usernames.Select(username => new KeyValuePair<string, string>("user:username", username));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistAddRequest Email(params string[] emails)
        {
            var parameters = emails.Select(email => new KeyValuePair<string, string>("email", email));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusBlacklistAddRequest RetroactiveAction(DisqusBlacklistEntryRetroactiveAction retroactiveAction)
        {
            if (retroactiveAction == DisqusBlacklistEntryRetroactiveAction.None) return this;

            Parameters.Add(new KeyValuePair<string, string>("retroactiveAction", retroactiveAction.ToString("D")));

            return this;
        }
    }
}
