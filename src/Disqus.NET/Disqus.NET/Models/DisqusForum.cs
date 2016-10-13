using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusForum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("raw_description")]
        public string RawDescription { get; set; }

        [JsonProperty("guidelines")]
        public string Guidelines { get; set; }

        [JsonProperty("raw_guidelines")]
        public string RawGuidelines { get; set; }

        [JsonProperty("favicon")]
        public DisqusImage Favicon { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? Created { get; set; }

        [JsonProperty("founder")]
        public string Founder { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("twitterName")]
        public string TwitterName { get; set; }

        [JsonProperty("signedUrl")]
        public string SignedUrl { get; set; }

        [JsonProperty("pk")]
        public string Pk { get; set; }

        [JsonProperty("daysAlive")]
        public int? DaysAlive { get; set; }

        [JsonProperty("daysThreadAlive")]
        public int? DaysThreadAlive { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("installCompleted")]
        public bool? InstallCompleted { get; set; }

        [JsonProperty("avatar")]
        public DisqusAvatar Avatar { get; set; }

        [JsonProperty("settings")]
        public DisqusForumSettings Settings { get; set; }

        [JsonProperty("numThreads")]
        public int? NumThreads { get; set; }

        [JsonProperty("numFollowers")]
        public int? NumFollowers { get; set; }

        [JsonProperty("numModerators")]
        public int? NumModerators { get; set; }

        [JsonProperty("colorScheme")]
        public string ColorScheme { get; set; }

        [JsonProperty("typeface")]
        public string TypeFace { get; set; }

        [JsonProperty("commentsLinkZero")]
        public string CommentsLinkZero { get; set; }

        [JsonProperty("commentsLinkOne")]
        public string CommentsLinkOne { get; set; }

        [JsonProperty("commentsLinkMultiple")]
        public string CommentsLinkMultiple { get; set; }

        [JsonProperty("forumCategory")]
        public DisqusForumCategory ForumCategory { get; set; }

        [JsonProperty("author")]
        public DisqusAuthor Author { get; set; }

        public static implicit operator DisqusForum(string str)
        {
            return new DisqusForum
            {
                Id = str
            };
        }
    }
}
