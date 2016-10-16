using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusUserUpdateProfileRequest : DisqusRequestBase
    {
        private DisqusUserUpdateProfileRequest()
        {
        }

        public static DisqusUserUpdateProfileRequest New()
        {
            return new DisqusUserUpdateProfileRequest();
        }

        public DisqusUserUpdateProfileRequest Name(string name)
        {
            Parameters.Add(new KeyValuePair<string, string>("name", name));

            return this;
        }

        public DisqusUserUpdateProfileRequest About(string about)
        {
            Parameters.Add(new KeyValuePair<string, string>("about", about));

            return this;
        }

        public DisqusUserUpdateProfileRequest Url(string url)
        {
            Parameters.Add(new KeyValuePair<string, string>("url", url));

            return this;
        }

        public DisqusUserUpdateProfileRequest Location(string location)
        {
            Parameters.Add(new KeyValuePair<string, string>("location", location));

            return this;
        }
    }
}
