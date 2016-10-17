using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusPostInclude
    {
        None = 0,
        Unapproved = 1,
        Approved = 2,
        Spam = 4,
        Deleted = 8,
        Flagged = 16,
        Highlighted = 32
    }
}
