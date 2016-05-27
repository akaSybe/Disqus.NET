namespace Disqus.NET
{
    public interface IDisqusResponse<out T> where T: class
    {
        DisqusApiResponseCode Code { get; }

        T Response { get; }
    }
}