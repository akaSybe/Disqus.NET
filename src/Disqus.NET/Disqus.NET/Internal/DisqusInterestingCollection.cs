using System.Collections.Generic;
using Newtonsoft.Json;

namespace Disqus.NET.Internal
{
    internal class DisqusInterestingCollection<T> where T: new() 
    {
        [JsonProperty("items")]
        public IEnumerable<DisqusInterestingItem> Items { get; set; }

        [JsonProperty("objects")]
        public Dictionary<string, T> Objects { get; set; }
    }
}
