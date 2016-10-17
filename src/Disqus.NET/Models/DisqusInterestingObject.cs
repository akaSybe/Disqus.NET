namespace Disqus.NET.Models
{
    public class DisqusInterestingObject<T>
    {
        public T Object { get; set; }

        public string Reason { get; set; }
    }
}
