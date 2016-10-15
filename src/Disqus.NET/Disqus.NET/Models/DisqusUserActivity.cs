using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusUserActivity
    {
        [JsonProperty("object")]
        public DisqusPost Object { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
