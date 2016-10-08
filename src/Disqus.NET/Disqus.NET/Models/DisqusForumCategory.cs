using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusForumCategory
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date_added")]
        public DateTime Added { get; set; }
    }
}
