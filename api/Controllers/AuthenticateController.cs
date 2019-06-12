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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net.Http.Headers;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticateController : ControllerBase
    {

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate()
        {
            var authorizationHeader = Request.Headers["Authorization"];
            if (!string.IsNullOrWhiteSpace(authorizationHeader))
            {
                var authHeader = AuthenticationHeaderValue.Parse(authorizationHeader);
                var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');
                string tokenHandler = GenerateToken(credentials[0],credentials[1]);
                return Ok(tokenHandler);
            }
            return BadRequest("Something  wrong");
        }
        [NonAction]
        private string GenerateToken(string username,string password)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcduiigeiugeiufguiefgifgefiefg"));
            var signingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
              issuer: "mysite.com",
              audience: "mysite.com",
              expires: DateTime.Now.AddMinutes(2),
              claims: claims,
              signingCredentials: signingCredential
            );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenHandler;
        }        
    }
}