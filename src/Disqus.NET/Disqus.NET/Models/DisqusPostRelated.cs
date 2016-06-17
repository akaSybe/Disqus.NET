using System;

namespace Disqus.NET.Models
{
    [Flags]
    public enum DisqusPostRelated
    {
        None = 0,
        Forum = 1,
        Thread = 2
    }
}