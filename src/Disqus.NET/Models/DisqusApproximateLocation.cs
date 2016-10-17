using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusApproximateLocation
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
