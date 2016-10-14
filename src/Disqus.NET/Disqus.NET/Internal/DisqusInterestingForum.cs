using System.Collections.Generic;
using Disqus.NET.Models;
using Newtonsoft.Json;

namespace Disqus.NET.Internal
{
    internal class DisqusInterestingForums
    {
        [JsonProperty("items")]
        public IEnumerable<DisqusInterestingForumItem> Items { get; set; }

        [JsonProperty("objects")]
        public Dictionary<string, DisqusForum> Objects { get; set; }
    }

    internal class DisqusInterestingForumItem
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
