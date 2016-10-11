using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusTrustedDomain
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("forum_id")]
        public int ForumId { get; set; }
    }
}
