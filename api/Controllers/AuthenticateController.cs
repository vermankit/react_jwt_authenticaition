using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace api.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticateController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("authenticate")]                
        public IActionResult Authenticate()
        {
            var claims = new[] {new Claim(ClaimTypes.Name,"ankit")};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcd"));
            var signingCredential = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken (
              issuer: "mysite.com",
              audience : "mysite.com",
              expires : DateTime.Now.AddMinutes(2),
              claims : claims,
              signingCredentials : signingCredential
            );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            
            return Ok(token);
        }       
    }
}