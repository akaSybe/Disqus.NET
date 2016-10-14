using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusForumValidateRequest: DisqusRequestBase
    {
        private DisqusForumValidateRequest(string forum)
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        public static DisqusForumValidateRequest New(string forum)
        {
            return new DisqusForumValidateRequest(forum);
        }

        public DisqusForumValidateRequest AdsProductLinksEnabled(bool adsProductLinksEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsProductLinksEnabled", adsProductLinksEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumValidateRequest AdsProductLinksThumbnailsEnabled(bool adsProductLinksThumbnailsEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsProductLinksThumbnailsEnabled", adsProductLinksThumbnailsEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumValidateRequest AdsProductStoriesEnabled(bool adsProductStoriesEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsProductStoriesEnabled", adsProductStoriesEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumValidateRequest AdsProductVideoEnabled(bool adsProductVideoEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsProductVideoEnabled", adsProductVideoEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumValidateRequest AdsPositionTopEnabled(bool adsPositionTopEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsPositionTopEnabled", adsPositionTopEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumValidateRequest AdsPositionBottomEnabled(bool adsPositionBottomEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsPositionBottomEnabled", adsPositionBottomEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumValidateRequest AdsPositionInThreadEnabled(bool adsPositionInThreadEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsPositionInthreadEnabled", adsPositionInThreadEnabled ? "1" : "0"));

            return this;
        }
    }
}
