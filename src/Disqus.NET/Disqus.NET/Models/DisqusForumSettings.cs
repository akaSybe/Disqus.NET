using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusForumSettings
    {
        [JsonProperty("supportLevel")]
        public int SupportLevel { get; set; }

        [JsonProperty("adsDRNativeEnabled")]
        public bool AdsDRNativeEnabled { get; set; }

        [JsonProperty("disable3rdPartyTrackers")]
        public bool Disable3rdPartyTrackers { get; set; }

        [JsonProperty("adsVideoEnabled")]
        public bool AdsVideoEnabled { get; set; }

        [JsonProperty("allowAnonPost")]
        public bool AlllowAnonPost { get; set; }

        [JsonProperty("audienceSyncEnabled")]
        public bool AudienceSyncEnabled { get; set; }

        [JsonProperty("unapproveLinks")]
        public bool UnapproveLinks { get; set; }

        [JsonProperty("linkAffiliationEnabled")]
        public bool LinkAffiliationEnabled { get; set; }

        [JsonProperty("adsProductLinksThumbnailsEnabled")]
        public bool AdsProductLinksThumbnailsEnabled { get; set; }

        [JsonProperty("adsProductStoriesEnabled")]
        public bool AdsProductStoriesEnabled { get; set; }

        [JsonProperty("organicDiscoveryEnabled")]
        public bool OrganicDiscoveryEnabled { get; set; }

        [JsonProperty("discoveryLocked")]
        public bool DiscoveryLocked { get; set; }

        [JsonProperty("hasCustomAvatar")]
        public bool HasCustomAvatar { get; set; }

        [JsonProperty("adsEnabled")]
        public bool AdsEnabled { get; set; }

        [JsonProperty("adsPositionTopEnabled")]
        public bool AdsPositionTopEnabled { get; set; }

        [JsonProperty("allowMedia")]
        public bool AllowMedia { get; set; }

        [JsonProperty("adultContent")]
        public bool AdultContent { get; set; }

        [JsonProperty("allowAnonVotes")]
        public bool AllowAnonVotes { get; set; }

        [JsonProperty("adsProductVideoEnabled")]
        public bool AdsProductVideoEnabled { get; set; }

        [JsonProperty("mustVerify")]
        public bool MustVerify { get; set; }

        [JsonProperty("mustVerifyEmail")]
        public bool MustVerifyEmail { get; set; }

        [JsonProperty("ssoRequired")]
        public bool SsoRequired { get; set; }

        [JsonProperty("mediaembedEnabled")]
        public bool MediaEmbedEnabled { get; set; }

        [JsonProperty("adsPositionBottomEnabled")]
        public bool AdsPositionBottomEnabled { get; set; }

        [JsonProperty("adsProductLinksEnabled")]
        public bool AdsProductLinksEnabled { get; set; }

        [JsonProperty("validateAllPosts")]
        public bool ValidateAllPosts { get; set; }

        [JsonProperty("adsSettingsLocked")]
        public bool AdsSettingsLocked { get; set; }

        [JsonProperty("isVIP")]
        public bool IsVip { get; set; }

        [JsonProperty("adsPositionInthreadEnabled")]
        public bool AdsPositionInThreadEnabled { get; set; }
    }
}
