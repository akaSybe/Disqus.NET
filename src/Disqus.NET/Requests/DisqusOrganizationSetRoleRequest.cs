using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusOrganizationSetRoleRequest : DisqusRequestBase
    {
        private DisqusOrganizationSetRoleRequest(int organizationId, int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("organization", organizationId.ToString()));
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));
        }

        private DisqusOrganizationSetRoleRequest(int organizationId, string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("organization", organizationId.ToString()));
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));
        }

        public static DisqusOrganizationSetRoleRequest New(int organizationId, int userId)
        {
            return new DisqusOrganizationSetRoleRequest(organizationId, userId);
        }

        public static DisqusOrganizationSetRoleRequest New(int organizationId, string username)
        {
            return new DisqusOrganizationSetRoleRequest(organizationId, username);
        }

        public DisqusOrganizationSetRoleRequest IsModerator()
        {
            Parameters.Add(new KeyValuePair<string, string>("isModerator", "1"));

            return this;
        }

        public DisqusOrganizationSetRoleRequest IsAdmin()
        {
            Parameters.Add(new KeyValuePair<string, string>("isAdmin", "1"));

            return this;
        }
    }
}
