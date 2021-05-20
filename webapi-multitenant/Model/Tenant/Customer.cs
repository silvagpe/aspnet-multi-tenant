using System;

namespace webapi_multitenant.Model.Tenant
{
    /// <summary>
    /// Customer for the tenant system
    /// </summary>
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }   

        public string Address { get; set; }
    }
}