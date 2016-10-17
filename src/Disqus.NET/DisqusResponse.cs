namespace Disqus.NET
{
    public class DisqusResponse<T> : IDisqusResponse<T> where T: class
    {
        public DisqusApiResponseCode Code { get; set; }

        public T Response { get; set; }
    }
}
