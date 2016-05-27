using Disqus.NET.Models;

namespace Disqus.NET
{
    public class CursoredDisqusResponse<T>: DisqusResponse<T> where T: class
    {
        public DisqusCursor Cursor { get; set; }
    }
}
