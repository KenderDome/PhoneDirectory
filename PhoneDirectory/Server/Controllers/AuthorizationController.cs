using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PhoneDirectory.Shared.DTOs;
using PhoneDirectory.Shared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhoneDirectory.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AuthorizationController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthorizationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("[action]")]
        public ActionResult<UserToken> Login([FromBody] UserInfo userInfo)
        {
            //Terrible password and no ssl or encryption, but it's just a proof of concept for a phone directory.
            if (userInfo.Password.Equals("admin", StringComparison.InvariantCultureIgnoreCase))
                return BuildToken(userInfo);
            else
                return BadRequest("Invalid password");
        }

        private UserToken BuildToken(UserInfo userinfo)
        {
            var claims = new List<Claim>()
            {
                new Claim("Name", "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
                  issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
