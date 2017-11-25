using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusPostDetailsRequest: DisqusRequestBase
    {
        private DisqusPostDetailsRequest(long postId)
        {
            Parameters.Add(new KeyValuePair<string, string>("post", postId.ToString()));
        }

        public static DisqusPostDetailsRequest New(long postId)
        {
            return new DisqusPostDetailsRequest(postId);
        }

        /// <summary>
        /// Allow to specify relations to include with your response.
        /// </summary>
        /// <param name="related"></param>
        /// <returns></returns>
        public DisqusPostDetailsRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }
    }
}
