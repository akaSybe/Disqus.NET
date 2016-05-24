using System;

namespace Disqus.NET.Models
{
    [Flags]
    public enum DisqusForumAttach
    {
        None = 0,
        FollowsForum = 1,
        ForumCategory = 2,
        Counters = 4,
        ForumDaysAlive = 8,
        ForumIntergration = 16
    }
}