using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusPostUpdateRequest : DisqusRequestBase
    {
        private DisqusPostUpdateRequest(long postId, string message)
        {
            Parameters.Add(new KeyValuePair<string, string>("post", postId.ToString()));
            Parameters.Add(new KeyValuePair<string, string>("message", message));
        }

        public static DisqusPostUpdateRequest New(long postId, string message)
        {
            return new DisqusPostUpdateRequest(postId, message);
        }
    }
}
