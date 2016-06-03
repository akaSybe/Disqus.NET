using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusAvatar: DisqusAvatarBase
    {
        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [JsonProperty("small")]
        public DisqusAvatarBase Small { get; set; }

        [JsonProperty("large")]
        public DisqusAvatarBase Large { get; set; }
    }
}
