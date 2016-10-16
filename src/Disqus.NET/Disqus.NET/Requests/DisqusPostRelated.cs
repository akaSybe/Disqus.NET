using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusPostRelated
    {
        None = 0,
        Forum = 1,
        Thread = 2
    }
}