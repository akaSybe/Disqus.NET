using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusCategoryListThreadRelated
    {
        None = 0,
        Forum = 1,
        Author = 2
    }
}
