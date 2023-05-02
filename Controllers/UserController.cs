using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace movie_db_api.Controllers
{

    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {

        private readonly ApiDbContext _context;
        private readonly IConfiguration _configuration;

        public UserController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user =  await _context.Users.FindAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var newUser = new User { nickname = user.nickname, email = user.email, password = user.password };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {

            var driver = await _context.Users.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            _context.Users.Remove(driver);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

