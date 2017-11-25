using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusForumDetailsRequest : DisqusRequestBase
    {
        private DisqusForumDetailsRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumDetailsRequest New(string forum)
        {
            return new DisqusForumDetailsRequest(forum);
        }

        public DisqusForumDetailsRequest Related(DisqusForumRelated related)
        {
            if (related == DisqusForumRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusForumDetailsRequest Attach(DisqusForumAttach attach)
        {
            if (attach == DisqusForumAttach.None) return this;

            var parameters = attach.ToStringArray().Select(a => new KeyValuePair<string, string>("attach", a));
            Parameters.AddRange(parameters);

            return this;
        }
    }
}
