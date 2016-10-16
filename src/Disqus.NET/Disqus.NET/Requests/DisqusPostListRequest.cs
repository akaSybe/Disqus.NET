using System;
using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusPostListRequest: DisqusRequestBase
    {
        private DisqusPostListRequest()
        {
        }

        public static DisqusPostListRequest New()
        {
            return new DisqusPostListRequest();
        }

        public DisqusPostListRequest Category(params int[] categories)
        {
            Parameters.AddRange(categories.Select(c => new KeyValuePair<string, string>("category", c.ToString())));

            return this;
        }

        /// <summary>
        /// Looks up a thread by ID
        /// </summary>
        /// <param name="threads"></param>
        /// <returns></returns>
        public DisqusPostListRequest Thread(params int[] threads)
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
        public DisqusPostListRequest Thread(params string[] threadLinks)
        {
            var parameters = threadLinks.Select(thread => new KeyValuePair<string, string>("thread:link", thread));
            Parameters.AddRange(parameters);

            return this;
        }

        /// <summary>
        /// Looks up a thread by ID
        /// </summary>
        /// <param name="forums"></param>
        /// <returns></returns>
        public DisqusPostListRequest Forum(params string[] forums)
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
        public DisqusPostListRequest Forum(bool all)
        {
            if (!all) return this;

            Parameters.Add(new KeyValuePair<string, string>("forum:all", ""));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public DisqusPostListRequest Start(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("start", timestamp.ToString("s")));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public DisqusPostListRequest End(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("end", timestamp.ToString("s")));

            return this;
        }

        public DisqusPostListRequest Since(DateTime timestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>("since", timestamp.ToString("s")));

            return this;
        }

        public DisqusPostListRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusPostListRequest Cursor(string cursor)
        {
            Parameters.Add(new KeyValuePair<string, string>("cursor", cursor));

            return this;
        }

        public DisqusPostListRequest Limit(int limit)
        {
            Parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return this;
        }

        public DisqusPostListRequest Query(string query)
        {
            Parameters.Add(new KeyValuePair<string, string>("query", query));

            return this;
        }

        public DisqusPostListRequest Include(DisqusPostInclude include)
        {
            if (include == DisqusPostInclude.None) return this;

            var parameters = include.ToStringArray().Select(r => new KeyValuePair<string, string>("include", r));
            Parameters.AddRange(parameters);

            return this;
        }

        public DisqusPostListRequest Order(DisqusOrder order)
        {
            Parameters.Add(new KeyValuePair<string, string>("order", order.ToString().ToLower()));

            return this;
        }
    }
}
