using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusPostListPopularRequest : DisqusRequestBase
    {
        private DisqusPostListPopularRequest()
        {
        }

        public static DisqusPostListPopularRequest New()
        {
            return new DisqusPostListPopularRequest();
        }

        public DisqusPostListPopularRequest Category(int category)
        {
            Parameters.Add(new KeyValuePair<string, string>("category", category.ToString()));

            return this;
        }

        /// <summary>
        /// Looks up a thread by ID
        /// </summary>
        /// <param name="forums"></param>
        /// <returns></returns>
        public DisqusPostListPopularRequest Forum(params string[] forums)
        {
            var parameters = forums.Select(forum => new KeyValuePair<string, string>("forum", forum));
            Parameters.AddRange(parameters);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="all"></param>
        /// <returns></returns>
        public DisqusPostListPopularRequest Forum(bool all)
        {
            if (!all) return this;

            Parameters.Add(new KeyValuePair<string, string>("forum:all", ""));

            return this;
        }

        /// <summary>
        /// Looks up a thread by ID
        /// </summary>
        /// <param name="threads"></param>
        /// <returns></returns>
        public DisqusPostListPopularRequest Thread(params int[] threads)
        {
            var parameters = threads.Select(thread => new KeyValuePair<string, string>("thread", thread.ToString()));
            Parameters.AddRange(parameters);

            return this;
        }

        /// <summary>
        /// Looks up a thread by link
        /// </summary>
        /// <param name="threadLinks"></param>
        /// <returns></returns>
        public DisqusPostListPopularRequest Thread(params string[] threadLinks)
        {
            var parameters = threadLinks.Select(thread => new KeyValuePair<string, string>("thread:link", thread));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusPostListPopularRequest Interval(DisqusPopularInterval interval)
        {
            Parameters.Add(new KeyValuePair<string, string>("interval", interval.AsParameterValue()));

            return this;
        }

        public DisqusPostListPopularRequest Query(string query)
        {
            Parameters.Add(new KeyValuePair<string, string>("query", query));

            return this;
        }

        public DisqusPostListPopularRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusPostListPopularRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusPostListPopularRequest Offset(int offset)
        {
            Parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return this;
        }

        public DisqusPostListPopularRequest Organization(int organizationId)
        {
            Parameters.Add(new KeyValuePair<string, string>("organization", organizationId.ToString()));

            return this;
        }

        public DisqusPostListPopularRequest Include(DisqusPostInclude include)
        {
            if (include == DisqusPostInclude.None) return this;

            var parameters = include.ToStringArray().Select(r => new KeyValuePair<string, string>("include", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusPostListPopularRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
