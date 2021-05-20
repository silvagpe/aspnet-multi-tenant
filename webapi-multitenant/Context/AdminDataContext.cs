using Microsoft.EntityFrameworkCore;
using webapi_multitenant.Model.Admin;

namespace webapi_multitenant.Context
{

    /// <summary>
    /// Administrative system
    /// </summary>
    public class AdminDataContext : DbContext
    {
        public AdminDataContext(DbContextOptions<AdminDataContext> options) : base(options)
        {
            
        }
        
        public DbSet<Tenant> Tenants { get; set; }
    }
}