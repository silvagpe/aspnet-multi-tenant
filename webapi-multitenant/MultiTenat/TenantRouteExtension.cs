using System;
using Microsoft.AspNetCore.Http;

namespace webapi_multitenant.MultiTenat
{
    /// <summary>
    /// Extract from url the cliente name
    /// Ex: http://localhost:5000/clientOne/endpoint
    ///     http://localhost:5000/clientTwo/endpoint
    /// </summary>
    public static class TenantRouteExtension
    {
        public static string GetTenantRoute(this HttpContext context)
        {
            string clientRoutePath = context.Request.Path.Value.Split("/", StringSplitOptions.RemoveEmptyEntries)[0];
            if (string.IsNullOrEmpty(clientRoutePath)){
                throw new System.Exception("Tenant route is not defined");                
            }
            return clientRoutePath;
        }        
    }

}