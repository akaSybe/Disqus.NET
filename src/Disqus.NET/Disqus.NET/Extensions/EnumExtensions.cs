using System;
using System.Linq;
using RestSharp.Extensions;

namespace Disqus.NET.Extensions
{
    public static class EnumExtensions
    {
        public static string[] ToStringArray(this Enum e)
        {
            return e.ToString().Split(',').Select(v => v.Trim().ToCamelCase()).ToArray();
        }
    }
}
