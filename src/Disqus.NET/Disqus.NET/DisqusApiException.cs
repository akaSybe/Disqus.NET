using System;

namespace Disqus.NET
{
    public class DisqusApiException: Exception
    {
        public DisqusApiResponseCode Code { get; private set; }

        public string Error { get; private set; }

        public DisqusApiException(DisqusApiResponseCode code, string error): base(error)
        {
            Code = code;
            Error = error;
        }
    }
}
