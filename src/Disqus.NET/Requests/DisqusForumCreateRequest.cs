using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusForumCreateRequest : DisqusRequestBase
    {
        private DisqusForumCreateRequest(string name, string shortName) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("name", name));
            Parameters.Add(new KeyValuePair<string, string>("short_name", shortName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shortName">id</param>
        /// <returns></returns>
        public static DisqusForumCreateRequest New(string name, string shortName)
        {
            return new DisqusForumCreateRequest(name, shortName);
        }

        public DisqusForumCreateRequest Website(string url)
        {
            Parameters.Add(new KeyValuePair<string, string>("website", url));

            return this;
        }

        public DisqusForumCreateRequest Category(DisqusForumSettingsCategory category)
        {
            if (category == DisqusForumSettingsCategory.None) return this;

            Parameters.Add(new KeyValuePair<string, string>("category", category.ToString("G")));

            return this;
        }

        public DisqusForumCreateRequest AdultContent(bool adultContent)
        {
            Parameters.Add(new KeyValuePair<string, string>("adultContent", adultContent ? "1" : "0"));

            return this;
        }

        public DisqusForumCreateRequest Attach(DisqusForumAttach attach)
        {
            if (attach == DisqusForumAttach.None) return this;

            Parameters.AddRange(attach.ToStringArray().Select(a => new KeyValuePair<string, string>("attach", a)));

            return this;
        }

        public DisqusForumCreateRequest Guidelines(string guidelines)
        {
            Parameters.Add(new KeyValuePair<string, string>("guidelines", guidelines));

            return this;
        }

        public DisqusForumCreateRequest Language(string language)
        {
            Parameters.Add(new KeyValuePair<string, string>("language", language));

            return this;
        }

        public DisqusForumCreateRequest ForumCategory(int forumCategory)
        {
            Parameters.Add(new KeyValuePair<string, string>("forumCategory", forumCategory.ToString()));

            return this;
        }

        public DisqusForumCreateRequest Description(string description)
        {
            Parameters.Add(new KeyValuePair<string, string>("description", description));

            return this;
        }
    }
}
