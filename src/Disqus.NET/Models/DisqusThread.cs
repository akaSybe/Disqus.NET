using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusThread
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("clean_title")]
        public string CleanTitle { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("raw_message")]
        public string RawMessage { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("feed")]
        public string Feed { get; set; }

        [JsonProperty("canModerate")]
        public bool CanModerate { get; set; }

        [JsonProperty("canPost")]
        public bool CanPost { get; set; }

        [JsonProperty("identifiers")]
        public IEnumerable<string> Identifiers { get; set; }

        [JsonProperty("category")]
        public DisqusCategory Category { get; set; }

        [JsonProperty("author")]
        public DisqusAuthor Author { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("isSpam")]
        public bool IsSpam { get; set; }

        [JsonProperty("isClosed")]
        public bool IsClosed { get; set; }

        [JsonProperty("signedLink")]
        public string SignedLink { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("forum")]
        public DisqusForum Forum { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("dislikes")]
        public int Dislikes { get; set; }

        [JsonProperty("userScore")]
        public int UserScore { get; set; }

        [JsonProperty("posts")]
        public int Posts { get; set; }

        [JsonProperty("userSubscription")]
        public bool UserSubscription { get; set; }

        [JsonProperty("highlightedPost")]
        public DisqusPost HighlightedPost { get; set; }

        public static implicit operator DisqusThread(string str)
        {
            return new DisqusThread
            {
                Id = str
            };
        }
    }
}
