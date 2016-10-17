using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusWhitelistEntryTypes
    {
        None = 0,
        User = 1,
        Email = 2
    }
}
