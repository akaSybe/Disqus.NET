using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusPost
    {
        /// <summary>
        /// The network-wide unique ID number associated with the comment.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The comment body with HTML formatting.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The unformatted comment body.
        /// </summary>
        [JsonProperty("raw_message")]
        public string RawMessage { get; set; }

        /// <summary>
        /// The timestamp of the comment when it was created in the Disqus system.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        // TODO: It may be DisqusForum object or string
        /// <summary>
        /// The Disqus shortname of the forum which the comment was posted under.
        /// </summary>
        [JsonProperty("forum")]
        public string Forum { get; set; }

        // TODO: It may be DisqusThread object or string
        /// <summary>
        /// The Disqus thread ID number that the comment belongs to. Typically this is expandable by using related=thread.
        /// </summary>
        [JsonProperty("thread")]
        public string Thread { get; set; }

        /// <summary>
        /// The ID number of the parent comment. Will return null if it's a top-level comment. NOTE: This is changing to a string in the near future. See latest API responses for current status
        /// </summary>
        [JsonProperty("parent")]
        public string Parent { get; set; }

        /// <summary>
        /// Information about the comment author
        /// </summary>
        [JsonProperty("author")]
        public DisqusAuthor Author { get; set; }

        /// <summary>
        /// The number of unique likes (upvotes) that the comment has received.
        /// </summary>
        [JsonProperty("likes")]
        public int Likes { get; set; }

        /// <summary>
        /// The number of dislikes (downvotes) a comment has received.
        /// </summary>
        [JsonProperty("dislikes")]
        public int Dislikes { get; set; }

        /// <summary>
        /// The sum of the likes (upvotes) and the dislikes (downvotes).
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; set; }

        /// <summary>
        /// Whether the comment has been edited by the commenter or moderator.
        /// </summary>
        [JsonProperty("isEdited")]
        public bool IsEdited { get; set; }

        /// <summary>
        /// Whether the comment has been deleted or not.
        /// </summary>
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the comment has been deleted by author or not.
        /// </summary>
        [JsonProperty("isDeletedByAuthor")]
        public bool IsDeletedByAuthor { get; set; }

        /// <summary>
        /// Whether or not the comment is publicly visible. Unapproved comments are only visible to the comment author and forum moderators.
        /// </summary>
        [JsonProperty("isApproved")]
        public bool IsApproved { get; set; }

        /// <summary>
        /// Whether or not the comment has been marked as spam.
        /// </summary>
        [JsonProperty("isSpam")]
        public bool IsSpam { get; set; }

        /// <summary>
        /// Whether or not a thread author or forum moderator has "highlighted" the comment.
        /// </summary>
        [JsonProperty("isHighlighted")]
        public bool IsHighlighted { get; set; }

        /// <summary>
        /// (currently unused) Whether the comment has been system-flagged.
        /// </summary>
        [JsonProperty("isJuliaFlagged")]
        public bool IsJuliaFlagged { get; set; }

        /// <summary>
        /// Whether or not the comment has been flagged by at least one other user.
        /// </summary>
        [JsonProperty("isFlagged")]
        public bool IsFlagged { get; set; }

        /// <summary>
        /// The number of unique flags that the comment has received from other users.
        /// </summary>
        [JsonProperty("numReports")]
        public int NumReports { get; set; }

        /// <summary>
        /// The score that the authenticated user has given to a particular comment. Typically this is just -1, 0 or 1.
        /// </summary>
        [JsonProperty("userScore")]
        public int? UserScore { get; set; }

        /// <summary>
        /// Approximate location
        /// <remarks>Will only return email if request is authenticated and authenticated user has 'admin' permission</remarks>
        /// </summary>
        [JsonProperty("approxLoc")]
        public DisqusApproximateLocation ApproximateLocation { get; set; }

        /// <summary>
        /// IP address from which comment was posted
        /// <remarks>Will only return email if request is authenticated and authenticated user has 'admin' permission</remarks>
        /// </summary>
        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }
    }
}
