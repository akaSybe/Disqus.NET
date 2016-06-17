using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusMediaMetadata
    {
        [JsonProperty("reate_method")]
        public string CreateMethod { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}