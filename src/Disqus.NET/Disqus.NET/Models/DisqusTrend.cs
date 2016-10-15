using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusTrend
    {
        [JsonProperty("thread")]
        public DisqusThread Thread { get; set; }

        [JsonProperty("postLikes")]
        public int PostLikes { get; set; }

        [JsonProperty("posts")]
        public int Posts { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }
    }
}
