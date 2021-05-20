using System;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace webapi_multitenant.MultiTenat
{
    public static class ConnectionStringExtension
    {
        public static string GetTenantConnectionString(this IConfiguration configuration, string tenant)
        {
            
            var connStr = configuration.GetConnectionString("TenantsConnection");

            if (connStr.Contains("__TENANT_DB__")){
                connStr = connStr.Replace("__TENANT_DB__", tenant);
            }else{
                throw new Exception("The connection string is invalid");
            }
            
            return connStr;
        }
    
    }
}