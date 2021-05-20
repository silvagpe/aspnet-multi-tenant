using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi_multitenant.Context;

namespace webapi_multitenant.Controllers
{
    public class CustomerController : ControllerBase
    {
        [HttpGet("/{tenantRoute}/customers")]
        public async Task<IActionResult> GetContacts(
            [FromRoute]string tenantRoute,[FromServices]TenantDataContext context)
        {
            var customers = await context.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {            
            return Ok(true);
        }        
    }    
}