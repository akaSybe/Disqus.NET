using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusWhitelistEntry
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("forum")]
        public string Forum { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("conflictingBlacklistRemoved")]
        public bool? ConflictingBlacklistRemoved { get; set; }
    }
}
