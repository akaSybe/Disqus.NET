using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusThreadRelated
    {
        None = 0,
        Forum = 1,
        Author = 2,
        Category = 4
    }
}
