using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DisqusId
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
