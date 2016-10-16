using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusCategoryCreateRequest : DisqusRequestBase
    {
        private DisqusCategoryCreateRequest(string forum, string title)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
            Parameters.Add(new KeyValuePair<string, string>("title", title));
        }

        public static DisqusCategoryCreateRequest New(string forum, string title)
        {
            return new DisqusCategoryCreateRequest(forum, title);
        }

        public DisqusCategoryCreateRequest Default(bool @default)
        {
            Parameters.Add(new KeyValuePair<string, string>("default", @default ? "1" : "0"));

            return this;
        }
    }
}
