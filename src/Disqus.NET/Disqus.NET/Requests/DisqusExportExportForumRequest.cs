using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusExportExportForumRequest: DisqusRequestBase
    {
        private DisqusExportExportForumRequest(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusExportExportForumRequest New(string forum)
        {
            return new DisqusExportExportForumRequest(forum);
        }

        public DisqusExportExportForumRequest Format(DisqusExportFormat format)
        {
            Parameters.Add(new KeyValuePair<string, string>("format", format.ToString("G").ToLower()));

            return this;
        }
    }
}
