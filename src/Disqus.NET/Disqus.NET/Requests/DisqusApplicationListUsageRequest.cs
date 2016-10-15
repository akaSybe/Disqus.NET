using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusApplicationListUsageRequest: DisqusRequestBase
    {
        private DisqusApplicationListUsageRequest()
        {
        }

        public static DisqusApplicationListUsageRequest New()
        {
            return new DisqusApplicationListUsageRequest();
        }

        public DisqusApplicationListUsageRequest Application(int applicationId)
        {
            Parameters.Add(new KeyValuePair<string, string>("application", applicationId.ToString()));

            return this;
        }

        public DisqusApplicationListUsageRequest Days(int days)
        {
            Parameters.Add(new KeyValuePair<string, string>("days", days.ToString()));

            return this;
        }
    }
}
