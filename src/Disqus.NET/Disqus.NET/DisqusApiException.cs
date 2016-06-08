using System;

namespace Disqus.NET
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>https://msdn.microsoft.com/en-us/library/ms229064(v=vs.100).aspx</remarks>
    [Serializable]
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
