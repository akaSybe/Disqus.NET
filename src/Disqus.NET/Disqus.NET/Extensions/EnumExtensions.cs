using System;
using System.Linq;
using Disqus.NET.Models;
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

        public static string AsParameterName(this DisqusAuthorLookupType type, string parameterName = "author")
        {
            switch (type)
            {
                case DisqusAuthorLookupType.Username:
                    return string.Format("{0}:{1}", parameterName, "username");
                case DisqusAuthorLookupType.Id:
                default:
                    return parameterName;
            }
        }

        public static string AsParameterValue(this DisqusThreadPopularInterval interval)
        {
            switch (interval)
            {
                case DisqusThreadPopularInterval.Interval1Hour:
                    return "1h";
                case DisqusThreadPopularInterval.Interval6Hours:
                    return "6h";
                case DisqusThreadPopularInterval.Interval12Hours:
                    return "12h";
                case DisqusThreadPopularInterval.Interval1Day:
                    return "1d";
                case DisqusThreadPopularInterval.Interval3Days:
                    return "3d";
                case DisqusThreadPopularInterval.Interval7Days:
                    return "7d";
                case DisqusThreadPopularInterval.Interval30Days:
                    return "30d";
                case DisqusThreadPopularInterval.Interval90Days:
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
