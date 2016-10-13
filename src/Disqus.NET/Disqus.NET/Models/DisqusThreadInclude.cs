using System;

namespace Disqus.NET.Models
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
