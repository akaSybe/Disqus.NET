using System;
using System.Linq;

using Disqus.NET.Requests;

namespace Disqus.NET.Extensions
{
    public static class EnumExtensions
    {
        public static string[] ToStringArray(this Enum e)
        {
            return e.ToString().Split(',').Select(v => v.Trim().ToCamelCase()).ToArray();
        }

        public static string AsParameterName(this DisqusThreadLookupType type)
        {
            switch (type)
            {
                case DisqusThreadLookupType.Identifier:
                    return "thread:ident";
                case DisqusThreadLookupType.Link:
                    return "thread:link";
                case DisqusThreadLookupType.Id:
                default:
                    return "thread";
            }
        }

        public static string AsParameterValue(this DisqusPopularInterval interval)
        {
            switch (interval)
            {
                case DisqusPopularInterval.Interval1Hour:
                    return "1h";
                case DisqusPopularInterval.Interval6Hours:
                    return "6h";
                case DisqusPopularInterval.Interval12Hours:
                    return "12h";
                case DisqusPopularInterval.Interval1Day:
                    return "1d";
                case DisqusPopularInterval.Interval3Days:
                    return "3d";
                case DisqusPopularInterval.Interval7Days:
                    return "7d";
                case DisqusPopularInterval.Interval30Days:
                    return "30d";
                case DisqusPopularInterval.Interval90Days:
                    return "90d";
                default:
                    return "";
            }
        }

        public static string AsParameterValue(this DisqusForumSettingsTypeface typeFace)
        {
            switch (typeFace)
            {
                case DisqusForumSettingsTypeface.Auto:
                    return "auto";
                case DisqusForumSettingsTypeface.Serif:
                    return "serif";
                case DisqusForumSettingsTypeface.SansSerif:
                    return "sans-serif";
                default:
                    return "";
            }
        }
    }
}
