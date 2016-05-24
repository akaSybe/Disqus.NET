namespace Disqus.NET
{
    public class DisqusResponse<T>
    {
        public DisqusErrorCode Code { get; set; }

        public string Error { get; set; }

        public T Response { get; set; }
    }
}
