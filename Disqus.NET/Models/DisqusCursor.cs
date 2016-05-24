namespace Disqus.NET.Models
{
    /// <summary>
    ///  <remarks>https://disqus.com/api/docs/cursors/</remarks>
    /// </summary>
    public class DisqusCursor
    {
        public string Id { get; set; }

        public string Prev { get; set; }

        public bool HasNext { get; set; }

        public string Next { get; set; }

        public bool HasPrev { get; set; }

        public string Total { get; set; }

        public bool More { get; set; }
    }
}
