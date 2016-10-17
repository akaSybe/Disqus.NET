using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusOrganizationRemoveAdminRequest : DisqusRequestBase
    {
        private DisqusOrganizationRemoveAdminRequest(int organizationId, int userId)
        {
            Parameters.Add(new KeyValuePair<string, string>("organization", organizationId.ToString()));
            Parameters.Add(new KeyValuePair<string, string>("user", userId.ToString()));
        }

        private DisqusOrganizationRemoveAdminRequest(int organizationId, string username)
        {
            Parameters.Add(new KeyValuePair<string, string>("organization", organizationId.ToString()));
            Parameters.Add(new KeyValuePair<string, string>("user:username", username));
        }

        public static DisqusOrganizationRemoveAdminRequest New(int organizationId, int userId)
        {
            return new DisqusOrganizationRemoveAdminRequest(organizationId, userId);
        }

        public static DisqusOrganizationRemoveAdminRequest New(int organizationId, string username)
        {
            return new DisqusOrganizationRemoveAdminRequest(organizationId, username);
        }
    }
}
