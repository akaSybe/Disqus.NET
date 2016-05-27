using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusUser
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
        /// 
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

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
        /// Whether or not the user has registered any forums under this account.
        /// </summary>
        [JsonProperty("isPrimary")]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isPowerContributor")]
        public bool IsPowerContributor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("disable3rdPartyTrackers")]
        public bool DisableThirdPartyTrackers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Whether or not the user has a registered account or not
        /// </summary>
        [JsonProperty("isAnonymous")]
        public bool IsAnonymous { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("numFollowers")]
        public int NumFollowers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("numFollowing")]
        public int NumFollowing { get; set; }

        /// <summary>
        /// The number of comments posted by the user.
        /// </summary>
        [JsonProperty("numPosts")]
        public int NumPosts { get; set; }

        /// <summary>
        /// The number of upvotes the user has received for their comments.
        /// </summary>
        [JsonProperty("numLikesReceived")]
        public int NumLikesReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("numForumsFollowing")]
        public int NumForumsFollowing { get; set; }

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
        /// Calculated user reputation. Same as reputation
        /// </summary>
        [JsonProperty("rep")]
        public double Rep { get; set; }

        /// <summary>
        /// Calculated user reputation. Same as rep.
        /// </summary>
        [JsonProperty("reputation")]
        public double Reputation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("signedUrl")]
        public string SignedUrl { get; set; }
    }
}
