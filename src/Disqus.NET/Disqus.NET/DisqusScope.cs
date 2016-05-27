using System;

namespace Disqus.NET
{
    [Flags]
    public enum DisqusScope
    {
        Read = 1,
        Write = 2,
        Email = 4,
        Admin = 8
    }
}