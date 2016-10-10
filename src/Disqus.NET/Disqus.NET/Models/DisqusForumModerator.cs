using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusForumModerator
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("forum")]
        public string Forum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Will only return value if request is authenticated</remarks>
        [JsonProperty("canAdminister")]
        public bool? CanAdminister { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Will only return value if request is authenticated</remarks>
        [JsonProperty("canEdit")]
        public bool? CanEdit { get; set; }

        [JsonProperty("user")]
        public DisqusUserBase User { get; set; }
    }
}
