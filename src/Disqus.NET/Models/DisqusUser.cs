using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusUser: DisqusUserBase
    {
        /// <summary>
        /// Whether or not the user is blocked
        /// <remarks>Authentication required</remarks>
        /// </summary>
        [JsonProperty("isBlocked")]
        public bool? IsBlocked { get; set; }

        /// <summary>
        /// Calculated user reputation. Same as reputation
        /// </summary>
        [JsonProperty("rep")]
        public double? Rep { get; set; }

        /// <summary>
        /// Calculated user reputation. Same as rep.
        /// </summary>
        [JsonProperty("reputation")]
        public double? Reputation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("numFollowers")]
        public int? NumFollowers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("numFollowing")]
        public int? NumFollowing { get; set; }

        /// <summary>
        /// The number of comments posted by the user.
        /// </summary>
        [JsonProperty("numPosts")]
        public int? NumPosts { get; set; }

        /// <summary>
        /// The number of upvotes the user has received for their comments.
        /// </summary>
        [JsonProperty("numLikesReceived")]
        public int? NumLikesReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("numForumsFollowing")]
        public int? NumForumsFollowing { get; set; }
    }
}
