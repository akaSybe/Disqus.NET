namespace Disqus.NET
{
    public class DisqusErrorResponse: IDisqusResponse<string>
    {
        public DisqusApiResponseCode Code { get; set; }

        public string Response { get; set; }
    }
}
