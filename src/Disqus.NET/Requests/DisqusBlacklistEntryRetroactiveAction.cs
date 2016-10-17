using System;

namespace Disqus.NET.Requests
{
    [Flags]
    public enum DisqusBlacklistEntryRetroactiveAction
    {
        None = 0,
        Kill = 1,
        Spam = 2
    }
}
