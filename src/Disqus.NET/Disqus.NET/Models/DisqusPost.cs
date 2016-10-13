using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusPost
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("raw_message")]
        public string RawMessage { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("approxLoc")]
        public DisqusApproximateLocation ApproximateLocation { get; set; }

        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("parent")]
        public string Parent { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("dislikes")]
        public int Dislikes { get; set; }

        [JsonProperty("numReports")]
        public int NumReports { get; set; }

        [JsonProperty("isEdited")]
        public bool IsEdited { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("isDeletedByAuthor")]
        public bool IsDeletedByAuthor { get; set; }

        [JsonProperty("isSpam")]
        public bool IsSpam { get; set; }

        [JsonProperty("isApproved")]
        public bool IsApproved { get; set; }

        [JsonProperty("isFlagged")]
        public bool IsFlagged { get; set; }

        [JsonProperty("isHighlighted")]
        public bool IsHighlighted { get; set; }

        [JsonProperty("media")]
        public IEnumerable<DisqusMedia> Media { get; set; }

        [JsonProperty("canVote")]
        public bool CanVote { get; set; }

        [JsonProperty("userScore")]
        public int? UserScore { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("author")]
        public DisqusAuthor Author { get; set; }

        [JsonProperty("forum")]
        public DisqusForum Forum { get; set; }

        [JsonProperty("thread")]
        public DisqusThread Thread { get; set; }

        //public DisqusPost ToDisqusPost()
        //{
        //    return new DisqusPost
        //    {
        //        Id = Id,
        //    };
        //}
    }
}
