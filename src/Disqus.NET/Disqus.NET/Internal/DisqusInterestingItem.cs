using Newtonsoft.Json;

namespace Disqus.NET.Internal
{
    internal class DisqusInterestingItem
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}