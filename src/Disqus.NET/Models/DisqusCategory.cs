using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusCategory
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("isDefault")]
        public bool? IsDefault { get; set; }

        [JsonProperty("forum")]
        public string Forum { get; set; }

        public static implicit operator DisqusCategory(string str)
        {
            int id;
            int.TryParse(str, out id);

            return new DisqusCategory
            {
                Id = id
            };
        }
    }
}
