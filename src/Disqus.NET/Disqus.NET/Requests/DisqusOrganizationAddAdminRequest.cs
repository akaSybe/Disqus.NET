using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusOrganizationAddAdminRequest : DisqusRequestBase
    {
        private DisqusOrganizationAddAdminRequest(int organizationId, int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("organization", organizationId.ToString()));
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));
        }

        private DisqusOrganizationAddAdminRequest(int organizationId, string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("organization", organizationId.ToString()));
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));
        }

        public static DisqusOrganizationAddAdminRequest New(int organizationId, int userId)
        {
            return new DisqusOrganizationAddAdminRequest(organizationId, userId);
        }

        public static DisqusOrganizationAddAdminRequest New(int organizationId, string username)
        {
            return new DisqusOrganizationAddAdminRequest(organizationId, username);
        }
    }
}
