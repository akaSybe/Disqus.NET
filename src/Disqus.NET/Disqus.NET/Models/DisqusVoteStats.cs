using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusVoteStats
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("vote")]
        public int Vote { get; set; }

        [JsonProperty("delta")]
        public int Delta { get; set; }

        [JsonProperty("likesDelta")]
        public int LikesDelta { get; set; }

        [JsonProperty("dislikesDelta")]
        public int DislikesDelta { get; set; }

        [JsonProperty("thread")]
        public DisqusThread Thread { get; set; }
    }
}
