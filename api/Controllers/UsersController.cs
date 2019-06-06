using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        // GET api/values
        [AllowAnonymous]
        [HttpPost("authenticate")]                
        public IActionResult Authenticate()
        {
            return null;
        }       
    }
}
