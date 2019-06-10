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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticateController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]                
        public IActionResult Authenticate(string username,string password)
        {
            var claims = new[] {new Claim(ClaimTypes.Name,"ankit")};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcduiigeiugeiufguiefgifgefiefg"));
            var signingCredential = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken (
              issuer: "mysite.com",
              audience : "mysite.com",
              expires : DateTime.Now.AddMinutes(2),
              claims : claims,
              signingCredentials : signingCredential
            );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            
            return Ok(tokenHandler);
        }       
    }
}