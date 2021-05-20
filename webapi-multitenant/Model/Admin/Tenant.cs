using System;

namespace webapi_multitenant.Model.Admin
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Used to validate route
        /// </summary>
        /// <value></value>
        public string TenantRoute { get; set; }
    }
}