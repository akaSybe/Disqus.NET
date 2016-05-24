using RestSharp.Serializers;

namespace Disqus.NET
{
    public class DisqusRequesterBase
    {
        protected ISerializer Serializer;

        public DisqusRequesterBase()
        {
            //Serializer = new Newtonsoft.Json.JsonSerializer();
        }
    }
}
