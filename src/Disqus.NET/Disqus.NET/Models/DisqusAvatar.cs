using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusAvatar: DisqusImage
    {
        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [JsonProperty("small")]
        public DisqusImage Small { get; set; }

        [JsonProperty("large")]
        public DisqusImage Large { get; set; }
    }
}
