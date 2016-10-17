using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusUserListFollowersAttach
    {
        None = 0,
        UserFlaggedUser = 1
    }
}
