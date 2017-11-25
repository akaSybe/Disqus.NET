using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusChannel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dateAdded")]
        public DateTime Added { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("bannerColor")]
        public string BannerColor { get; set; }

        [JsonProperty("bannerColorHex")]
        public string BannerColorHex { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("isAggregation")]
        public bool IsAggregation { get; set; }

        [JsonProperty("enableCuration")]
        public bool EnableCuration { get; set; }

        [JsonProperty("isCategory")]
        public bool IsCategory { get; set; }

        [JsonProperty("adminOnly")]
        public bool AdminOnly { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("options")]
        public DisqusChannelOptions Options { get; set; }

        public static implicit operator DisqusChannel(string str)
        {
            return new DisqusChannel
            {
                Id = str
            };
        }
    }
}
