using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusBlacklistEntryTypes
    {
        None = 0,
        Domain = 1,
        Word = 2,
        IpAddress = 4,
        User = 8,
        ThreadSlug = 16,
        Email = 32,
        BrandUnsafeWord = 64
    }
}
