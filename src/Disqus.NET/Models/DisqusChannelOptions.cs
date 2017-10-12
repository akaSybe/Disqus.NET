using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusChannelOptions
    {
        [JsonProperty("banner_color")]
        public string BannerColor { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("banner_timestamp")]
        public string BannerTimestamp { get; set; }

        [JsonProperty("avatar_timestamp")]
        public string AvatarTimestamp { get; set; }
    }
}