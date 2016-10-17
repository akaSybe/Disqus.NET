using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    /// <summary>
    ///  <remarks>https://disqus.com/api/docs/cursors/</remarks>
    /// </summary>
    public class DisqusCursor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("prev")]
        public string Prev { get; set; }

        [JsonProperty("hasNext")]
        public bool HasNext { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("hasPrev")]
        public bool HasPrev { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("more")]
        public bool More { get; set; }
    }
}
