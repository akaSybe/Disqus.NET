using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusAdmin: DisqusUserBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Will only return value if request is authenticated and authenticated user is admin of organization</remarks>
        [JsonProperty("isVerified")]
        public bool? IsVerified { get; set; }
    }
}
