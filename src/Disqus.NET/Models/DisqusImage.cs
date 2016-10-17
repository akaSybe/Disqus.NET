using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusImage
    {
        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("cache")]
        public string Cache { get; set; }
    }
}
