using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;
using Disqus.NET.Models;

namespace Disqus.NET.Requests
{
    public class DisqusForumAddModeratorRequest : DisqusRequestBase
    {
        private DisqusForumAddModeratorRequest(string forum, string username) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));
        }

        private DisqusForumAddModeratorRequest(string forum, int userId) : base()
        {
            Parameters.Add(new KeyValuePair<string, string>("forum", forum));
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forum"></param>
        /// <param name="username">id</param>
        /// <returns></returns>
        public static DisqusForumAddModeratorRequest New(string forum, string username)
        {
            return new DisqusForumAddModeratorRequest(forum, username);
        }

        public static DisqusForumAddModeratorRequest New(string forum, int userId)
        {
            return new DisqusForumAddModeratorRequest(forum, userId);
        }

        public DisqusForumAddModeratorRequest CanAdminister(bool canAdminister)
        {
            Parameters.Add(new KeyValuePair<string, string>("canAdminister", canAdminister ? "1" : "0"));

            return this;
        }

        public DisqusForumAddModeratorRequest CanEdit(bool canEdit)
        {
            Parameters.Add(new KeyValuePair<string, string>("canEdit", canEdit ? "1" : "0"));

            return this;
        }
    }
}
