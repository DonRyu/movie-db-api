using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWT_NET_PRAC.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {

        private readonly ApiDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(ApiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("isLogin")]
        public async Task<IActionResult> IsLogin(String token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);
                var email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                var users = await _context.Users.ToListAsync();
                var filteredUsers = users.Where(u => u.email == email);

                return Ok(new {Login = true});

            }
            catch (SecurityTokenException)
            {
                return BadRequest("Invalid token");
            }

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var users = await _context.Users.ToListAsync();
            var filteredUsers = users.Where(u => u.email == request.email && u.password == request.password);
            if (!filteredUsers.Any())
            {
                return Ok(new { Msg = "Wrong account" });
            }
            string token = CreateToken(filteredUsers.ElementAt(0));
            return Ok(new { token });
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}