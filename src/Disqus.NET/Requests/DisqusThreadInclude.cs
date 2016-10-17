using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusThreadInclude
    {
        None = 0,
        Open = 1,
        Closed = 2,
        Killed = 4
    }
}
