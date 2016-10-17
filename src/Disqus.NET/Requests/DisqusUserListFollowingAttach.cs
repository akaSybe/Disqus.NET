using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusUserListFollowingAttach
    {
        None = 0,
        UserFlaggedUser = 1
    }
}
