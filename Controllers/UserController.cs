﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace movie_db_api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {

        private readonly ApiDbContext _context;

        public UserController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            await _context.Users.FindAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("post")]
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
        public async Task<IActionResult> Delete([FromBody] User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

