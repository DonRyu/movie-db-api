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

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ApiDbContext _context;
        public AuthController(ApiDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var users = await _context.Users.ToListAsync();
            var filteredUsers =users.Where(u=>u.email == request.email);

            return Ok(filteredUsers);
        }

    }
}