using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusThreadListHotRequest : DisqusRequestBase
    {
        private DisqusThreadListHotRequest() : base()
        {
        }

        public static DisqusThreadListHotRequest New()
        {
            return new DisqusThreadListHotRequest();
        }

        public DisqusThreadListHotRequest Category(params int[] categories)
        {
            var parameters = categories.Select(id => new KeyValuePair<string, string>("category", id.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListHotRequest Forum(params string[] forums)
        {
            var parameters = forums.Select(forum=> new KeyValuePair<string, string>("forum", forum));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListHotRequest Author(params string[] authors)
        {
            var parameters = authors.Select(author => new KeyValuePair<string, string>("author:username", author));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListHotRequest Author(params int[] authors)
        {
            var parameters = authors.Select(author => new KeyValuePair<string, string>("author", author.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListHotRequest Related(DisqusThreadRelated related)
        {
            if (related == DisqusThreadRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusThreadListHotRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusThreadListHotRequest Include(DisqusThreadInclude include)
        {
            if (include == DisqusThreadInclude.None) return this;

            var parameters = include.ToStringArray().Select(i => new KeyValuePair<string, string>("include", i));
            Parameters.AddRange(parameters);

            return this;
        }
    }
}
