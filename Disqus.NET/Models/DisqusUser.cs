using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("joinedAt")]
        public DateTime Joined { get; set; }
    }
}
