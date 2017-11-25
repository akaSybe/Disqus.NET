using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusForumUpdateRequest : DisqusRequestBase
    {
        private DisqusForumUpdateRequest(string forum) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forum"></param>
        /// <returns></returns>
        public static DisqusForumUpdateRequest New(string forum)
        {
            return new DisqusForumUpdateRequest(forum);
        }

        public DisqusForumUpdateRequest Name(string name)
        {
            Parameters.Add(new KeyValuePair<string, string>("name", name));

            return this;
        }

        public DisqusForumUpdateRequest Description(string description)
        {
            Parameters.Add(new KeyValuePair<string, string>("description", description));

            return this;
        }

        public DisqusForumUpdateRequest Website(string url)
        {
            Parameters.Add(new KeyValuePair<string, string>("website", url));

            return this;
        }

        public DisqusForumUpdateRequest Sort(DisqusForumUpdateSort sort)
        {
            Parameters.Add(new KeyValuePair<string, string>("sort", sort.ToString("D")));

            return this;
        }

        public DisqusForumUpdateRequest FlagThreshold(bool flagThreshold)
        {
            Parameters.Add(new KeyValuePair<string, string>("flagThreshold", flagThreshold ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest ColorScheme(DisqusForumSettingsColorScheme colorScheme)
        {
            Parameters.Add(new KeyValuePair<string, string>("colorScheme", colorScheme.ToString("G").ToLower()));

            return this;
        }

        public DisqusForumUpdateRequest CommentsLinkOne(string commentsLinkOne)
        {
            Parameters.Add(new KeyValuePair<string, string>("commentsLinkOne", commentsLinkOne));

            return this;
        }

        public DisqusForumUpdateRequest CommentsLinkZero(string commentsLinkZero)
        {
            Parameters.Add(new KeyValuePair<string, string>("commentsLinkZero", commentsLinkZero));

            return this;
        }

        public DisqusForumUpdateRequest CommentsLinkMultiple(string commentsLinkMultiple)
        {
            Parameters.Add(new KeyValuePair<string, string>("commentsLinkMultiple", commentsLinkMultiple));

            return this;
        }

        public DisqusForumUpdateRequest Guidelines(string guidelines)
        {
            Parameters.Add(new KeyValuePair<string, string>("guidelines", guidelines));

            return this;
        }

        public DisqusForumUpdateRequest AdsPositionTopEnabled(bool adsPositionTopEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsPositionTopEnabled", adsPositionTopEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest AdsPositionBottomEnabled(bool adsPositionBottomEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsPositionBottomEnabled", adsPositionBottomEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest AdsPositionInThreadEnabled(bool adsPositionInThreadEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsPositionInthreadEnabled", adsPositionInThreadEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest AdsProductLinksEnabled(bool adsProductLinksEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsProductLinksEnabled", adsProductLinksEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest AdsProductVideoEnabled(bool adsProductVideoEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsProductVideoEnabled", adsProductVideoEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest AdsProductStoriesEnabled(bool adsProductStoriesEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("adsProductStoriesEnabled", adsProductStoriesEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest UnapproveLinks(bool unapproveLinks)
        {
            Parameters.Add(new KeyValuePair<string, string>("unapproveLinks", unapproveLinks ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest LinkAffiliationEnabled(bool linkAffiliationEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("linkAffiliationEnabled", linkAffiliationEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest Category(DisqusForumSettingsCategory category)
        {
            if (category == DisqusForumSettingsCategory.None) return this;

            Parameters.Add(new KeyValuePair<string, string>("category", category.ToString("G")));

            return this;
        }

        public DisqusForumUpdateRequest Attach(DisqusForumAttach attach)
        {
            if (attach == DisqusForumAttach.None) return this;

            Parameters.AddRange(attach.ToStringArray().Select(a => new KeyValuePair<string, string>("attach", a)));

            return this;
        }

        public DisqusForumUpdateRequest OrganicDiscoveryEnabled(bool organicDiscoveryEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("organicDiscoveryEnabled", organicDiscoveryEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest TwitterName(string twitterName)
        {
            Parameters.Add(new KeyValuePair<string, string>("twitterName", twitterName));

            return this;
        }

        public DisqusForumUpdateRequest InstallCompleted(bool installCompleted)
        {
            Parameters.Add(new KeyValuePair<string, string>("installCompleted", installCompleted ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest UnapproveReputationLevel(DisqusForumUnapproveReputationLevel unapproveReputationLevel)
        {
            if (unapproveReputationLevel == DisqusForumUnapproveReputationLevel.None) return this;

            Parameters.Add(new KeyValuePair<string, string>("unapproveReputationLevel", unapproveReputationLevel.ToString("D")));

            return this;
        }

        public DisqusForumUpdateRequest AllowAnonymousPosts(bool allowAnonymousPosts)
        {
            Parameters.Add(new KeyValuePair<string, string>("allowAnonymousPosts", allowAnonymousPosts ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest TranslationLanguage(string translationLanguage)
        {
            Parameters.Add(new KeyValuePair<string, string>("translationLanguage", translationLanguage));

            return this;
        }

        public DisqusForumUpdateRequest ModeratorBadgeText(string moderatorBadgeText)
        {
            Parameters.Add(new KeyValuePair<string, string>("moderatorBadgeText", moderatorBadgeText));

            return this;
        }

        public DisqusForumUpdateRequest ShouldError(bool shouldError)
        {
            Parameters.Add(new KeyValuePair<string, string>("shouldError", shouldError ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest AdultContent(bool adultContent)
        {
            Parameters.Add(new KeyValuePair<string, string>("adultContent", adultContent ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest ForumCategory(int forumCategory)
        {
            Parameters.Add(new KeyValuePair<string, string>("forumCategory", forumCategory.ToString()));

            return this;
        }

        public DisqusForumUpdateRequest DisableThirdPartyTrackers(bool disableThirdPartyTrackers)
        {
            Parameters.Add(new KeyValuePair<string, string>("disableThirdPartyTrackers", disableThirdPartyTrackers ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest FlaggingNotifications(bool flaggingNotifications)
        {
            Parameters.Add(new KeyValuePair<string, string>("flaggingNotifications", flaggingNotifications ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest MediaEmbedEnabled(bool mediaEmbedEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("mediaembedEnabled", mediaEmbedEnabled ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest Typeface(DisqusForumSettingsTypeface typeface)
        {
            if (typeface == DisqusForumSettingsTypeface.None) return this;

            Parameters.Add(new KeyValuePair<string, string>("typeface", typeface.AsParameterValue()));

            return this;
        }

        public DisqusForumUpdateRequest DaysThreadAlive(int daysThreadAlive)
        {
            Parameters.Add(new KeyValuePair<string, string>("daysThreadAlive", daysThreadAlive.ToString()));

            return this;
        }

        public DisqusForumUpdateRequest ValidateAllPosts(bool validateAllPosts)
        {
            Parameters.Add(new KeyValuePair<string, string>("validateAllPosts", validateAllPosts ? "1" : "0"));

            return this;
        }

        public DisqusForumUpdateRequest FlaggingEnabled(bool flaggingEnabled)
        {
            Parameters.Add(new KeyValuePair<string, string>("flaggingEnabled", flaggingEnabled ? "1" : "0"));

            return this;
        }
    }
}
