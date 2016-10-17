using System;
using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusThreadCreateRequest : DisqusRequestBase
    {
        private DisqusThreadCreateRequest(string forum, string title) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
            Parameters.Add(new KeyValuePair<string, string>("title", title));
        }

        public static DisqusThreadCreateRequest New(string forum, string title)
        {
            return new DisqusThreadCreateRequest(forum, title);
        }

        public DisqusThreadCreateRequest Category(int categoryId)
        {
            Parameters.Add(new KeyValuePair<string, string>("category", categoryId.ToString()));

            return this;
        }

        public DisqusThreadCreateRequest Url(string url)
        {
            Parameters.Add(new KeyValuePair<string, string>("url", url));

            return this;
        }

        public DisqusThreadCreateRequest Date(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("date", timestamp.ToString("s")));

            return this;
        }

        public DisqusThreadCreateRequest Message(string message)
        {
            Parameters.Add(new KeyValuePair<string, string>("message", message));

            return this;
        }

        public DisqusThreadCreateRequest Identifier(string identifier)
        {
            Parameters.Add(new KeyValuePair<string, string>("identifier", identifier));

            return this;
        }

        public DisqusThreadCreateRequest Slug(string slug)
        {
            Parameters.Add(new KeyValuePair<string, string>("slug", slug));

            return this;
        }        
    }
}
