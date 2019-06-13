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
using Microsoft.Extensions.Options;
using api.Entities;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticateController : ControllerBase
    {
        private IOptions<AppSettings> _options;
       
        public AuthenticateController(IOptions<AppSettings> options)
        {
                 _options = options;
        }
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
                string tokenHandler = GenerateToken(credentials[0], credentials[1]);
                return Ok(tokenHandler);
            }
            return BadRequest("Something  wrong");
        }
        [NonAction]
        private string GenerateToken(string username, string password)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Secret));
            var signingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
              issuer: _options.Value.Issuer,
              audience: _options.Value.Audience,
              expires: DateTime.Now.AddMinutes(_options.Value.Expiry),
              claims: claims,
              signingCredentials: signingCredential
            );
            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            
            return tokenHandler;
        }
    }
}