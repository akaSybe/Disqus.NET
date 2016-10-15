using System;
using Newtonsoft.Json;

namespace Disqus.NET.Models
{
    public class DisqusImport
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("forum")]
        public string Forum { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("finishedAt")]
        public DateTime? FinishedAt { get; set; }

        [JsonProperty("startedAt")]
        public DateTime? StartedAt { get; set; }

        [JsonProperty("chunksDone")]
        public int ChunksDone { get; set; }

        [JsonProperty("chunksTotal")]
        public int ChunksTotal { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("statusName")]
        public int StatusName { get; set; }
    }
}
