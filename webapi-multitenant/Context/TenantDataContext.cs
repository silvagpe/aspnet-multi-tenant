using Microsoft.EntityFrameworkCore;
using webapi_multitenant.Model.Admin;
using webapi_multitenant.Model.Tenant;

namespace webapi_multitenant.Context
{
    public class TenantDataContext : DbContext
    {
        public TenantDataContext(DbContextOptions<TenantDataContext> options) : base(options)
        {

        }
        
        public DbSet<Customer> Customers { get; set; }
    }
}