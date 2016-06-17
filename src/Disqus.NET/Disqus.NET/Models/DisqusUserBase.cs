using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusUserBase
    {
        /// <summary>
        /// The network-wide unique ID of the user. This never changes, even if the person changes their unique username.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The unique username associated with the account.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The display name of the user as entered in their account settings.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email address of the user
        /// <remarks>Will only return email if request is authenticated and authenticated user has 'email' permission</remarks>
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Hashed email address of the user
        /// <remarks>Will only return email if request is authenticated and authenticated user has 'email' permission</remarks>
        /// </summary>
        [JsonProperty("emailHash")]
        public string EmailHash { get; set; }

        /// <summary>
        /// The user's bio.
        /// </summary>
        [JsonProperty("about")]
        public string About { get; set; }

        /// <summary>
        /// The date/time that the user created the account.
        /// </summary>
        [JsonProperty("joinedAt")]
        public DateTime Joined { get; set; }

        /// <summary>
        /// Location that user specified in their account settings.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// The user's website URL as entered in their account settings.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The disqus.com permalink URL to their profile.
        /// </summary>
        [JsonProperty("profileUrl")]
        public string ProfileUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("signedUrl")]
        public string SignedUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("disable3rdPartyTrackers")]
        public bool DisableThirdPartyTrackers { get; set; }

        /// <summary>
        /// Whether or not the person making the request is following the user.
        /// <remarks>Will only return true if request is authenticated, and authenticated user has chosen to follow this user.</remarks>
        /// </summary>
        [JsonProperty("isFollowing")]
        public bool? IsFollowing { get; set; }

        /// <summary>
        /// Whether or not the user follows the person making the request.
        /// <remarks>Will only return true if request is authenticated, and the user has chosen to follow authenticated user.</remarks>
        /// </summary>
        [JsonProperty("isFollowedBy")]
        public bool? IsFollowedBy { get; set; }

        /// <summary>
        /// <remarks>Will only return value if request is authenticated</remarks>
        /// </summary>
        [JsonProperty("homeOnboardingComplete")]
        public bool? HomeOnboardingComplete { get; set; }

        /// <summary>
        /// <remarks>Will only return value if request is authenticated</remarks>
        /// </summary>
        [JsonProperty("homeFeedOnboardingComplete")]
        public bool? HomeFeedOnboardingComplete { get; set; }
    }
}
