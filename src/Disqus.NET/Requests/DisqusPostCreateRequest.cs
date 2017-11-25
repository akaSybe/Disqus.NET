using System;
using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusPostCreateRequest: DisqusRequestBase
    {
        private DisqusPostCreateRequest(string message)
        {
            Parameters.Add(new KeyValuePair<string, string>("message", message));
        }

        public static DisqusPostCreateRequest New(string message)
        {
            return new DisqusPostCreateRequest(message);
        }

        public DisqusPostCreateRequest Parent(int parentPostId)
        {
            Parameters.Add(new KeyValuePair<string, string>("parent", parentPostId.ToString()));

            return this;
        }

        public DisqusPostCreateRequest Thread(string thread)
        {
            Parameters.Add(new KeyValuePair<string, string>("thread", thread));

            return this;
        }

        public DisqusPostCreateRequest AuthorEmail(string email)
        {
            Parameters.Add(new KeyValuePair<string, string>("author_email", email));

            return this;
        }

        public DisqusPostCreateRequest AuthorName(string name)
        {
            Parameters.Add(new KeyValuePair<string, string>("author_name", name));

            return this;
        }

        public DisqusPostCreateRequest AuthorUrl(string url)
        {
            Parameters.Add(new KeyValuePair<string, string>("author_url", url));

            return this;
        }

        public DisqusPostCreateRequest State(DisqusPostState state)
        {
            Parameters.Add(new KeyValuePair<string, string>("state", state.ToString("G").ToLower()));

            return this;
        }

        public DisqusPostCreateRequest Date(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("date", timestamp.ToString("s")));

            return this;
        }

        public DisqusPostCreateRequest IpAddress(string ipAddress)
        {
            Parameters.Add(new KeyValuePair<string, string>("ip_address", ipAddress));

            return this;
        }
    }
}
