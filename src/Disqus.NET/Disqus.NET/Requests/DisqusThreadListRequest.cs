using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusThreadListRequest: DisqusRequestBase
    {
        private DisqusThreadListRequest() : base()
        {
        }

        public static DisqusThreadListRequest New()
        {
            return new DisqusThreadListRequest();
        }

        public DisqusThreadListRequest Category(params int[] categories)
        {
            var parameters = categories.Select(id => new KeyValuePair<string, string>("category", id.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListRequest Forum(params string[] forums)
        {
            var parameters = forums.Select(forum=> new KeyValuePair<string, string>("forum", forum));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListRequest Thread(DisqusThreadLookupType lookupType, params string[] threads)
        {
            var parameters = threads.Select(thread => new KeyValuePair<string, string>(lookupType.AsParameterName(), thread));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListRequest Author(params string[] authors)
        {
            var parameters = authors.Select(author => new KeyValuePair<string, string>("author:username", author));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListRequest Author(params int[] authors)
        {
            var parameters = authors.Select(author => new KeyValuePair<string, string>("author", author.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListRequest Since(string timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp));

            return this;
        }

        public DisqusThreadListRequest Related(DisqusThreadRelated related)
        {
            if (related == DisqusThreadRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusThreadListRequest Attach(DisqusThreadAttach attach)
        {
            if (attach == DisqusThreadAttach.None) return this;

            var parameters = attach.ToStringArray().Select(a => new KeyValuePair<string, string>("attach", a));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusThreadListRequest Include(DisqusThreadInclude include)
        {
            if (include == DisqusThreadInclude.None) return this;

            var parameters = include.ToStringArray().Select(i => new KeyValuePair<string, string>("include", i));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
