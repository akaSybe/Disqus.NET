using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusMedia
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("post")]
        public string Post { get; set; }

        [JsonProperty("thread")]
        public string Thread { get; set; }

        [JsonProperty("forum")]
        public string Forum { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("htmlWidth")]
        public int? HtmlWidth { get; set; }

        [JsonProperty("htmlHeight")]
        public int? HtmlHeight { get; set; }

        [JsonProperty("mediaType")]
        public string MediaType { get; set; }

        [JsonProperty("metadata")]
        public DisqusMediaMetadata Metadata { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("thumbnailURL")]
        public string ThumbnailURL { get; set; }

        [JsonProperty("thumbnailWidth")]
        public int ThumbnailWidth { get; set; }

        [JsonProperty("thumbnailHeight")]
        public int ThumbnailHeight { get; set; }

        [JsonProperty("providerName")]
        public string ProviderName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("resolvedUrl")]
        public string ResolvedUrl { get; set; }
    }
}
