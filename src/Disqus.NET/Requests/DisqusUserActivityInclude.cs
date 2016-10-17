using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusUserActivityInclude
    {
        None = 0,
        User = 1,
        Replies = 2,
        Following = 4
    }
}
