using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using webapi_multitenant.Context;

namespace webapi_multitenant.MultiTenat
{
    
    public static class TenantDataContextExtension
    {
        public static void AddCustomDataContext(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddScoped(provider =>
            {
                var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
                var httpContext = httpContextAccessor.HttpContext;
                
                string tenantRoute = httpContext.GetTenantRoute();
                                
                //Validate tenant has access
                var masterContext = provider.GetService<AdminDataContext>();
                if (masterContext.Tenants.Where(x => x.TenantRoute == tenantRoute).FirstOrDefault() == null){
                    
                    throw new UnauthorizedAccessException("Tenant invalid");                    
                }

                var connString = configuration.GetTenantConnectionString(tenantRoute);
                var opts = new DbContextOptionsBuilder<TenantDataContext>();
                opts.UseNpgsql(connString, 
                    s => s
                    .EnableRetryOnFailure()                    
                    .MigrationsAssembly(typeof(Program).Assembly.FullName)
                );
                opts.EnableSensitiveDataLogging();
                
                var tenantDataContext = new TenantDataContext(opts.Options);
                tenantDataContext.Database.Migrate();

                return tenantDataContext;               
            });
        }
    }
}