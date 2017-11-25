using System.Collections.Generic;

using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadUpdateRequest : DisqusRequestBase
    {
        private DisqusThreadUpdateRequest(DisqusThreadLookupType lookupType, string thread) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
        }

        public static DisqusThreadUpdateRequest New(DisqusThreadLookupType lookupType, string thread)
        {
            return new DisqusThreadUpdateRequest(lookupType, thread);
        }

        public DisqusThreadUpdateRequest Category(int categoryId)
        {
            Parameters.Add(new KeyValuePair<string, string>("category", categoryId.ToString()));

            return this;
        }

        public DisqusThreadUpdateRequest Forum(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));

            return this;
        }

        public DisqusThreadUpdateRequest Title(string title)
        {
            Parameters.Add(new KeyValuePair<string, string>("title", title));

            return this;
        }

        public DisqusThreadUpdateRequest Url(string url)
        {
            Parameters.Add(new KeyValuePair<string, string>("url", url));

            return this;
        }

        public DisqusThreadUpdateRequest Author(int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("author", userId.ToString()));

            return this;
        }

        public DisqusThreadUpdateRequest Author(string userName)
        {
            Parameters.Add(new KeyValuePair<string, string>("author:username", userName));

            return this;
        }

        public DisqusThreadUpdateRequest Message(string message)
        {
            Parameters.Add(new KeyValuePair<string, string>("message", message));

            return this;
        }

        public DisqusThreadUpdateRequest Slug(string slug)
        {
            Parameters.Add(new KeyValuePair<string, string>("slug", slug));

            return this;
        }

        public DisqusThreadUpdateRequest OldIdentifier(string oldIdentifier)
        {
            Parameters.Add(new KeyValuePair<string, string>("old_identifier", oldIdentifier));

            return this;
        }

        public DisqusThreadUpdateRequest Identifier(string identifier)
        {
            Parameters.Add(new KeyValuePair<string, string>("identifier", identifier));

            return this;
        }
    }
}
