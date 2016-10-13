using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusRequestBase
    {
        public List<KeyValuePair<string, string>> Parameters { get; }

        protected DisqusRequestBase()
        {
            Parameters = new List<KeyValuePair<string, string>>();
        }
    }
}
