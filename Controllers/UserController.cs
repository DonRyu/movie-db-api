using System;
using Microsoft.AspNetCore.Mvc;

namespace movie_db_api.Controllers
{
	[ApiController]
	[Route("controller")]
	public class UserController : ControllerBase
    {
		
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok();
		}

		[HttpPost]
		[Route("post")]
		public async Task<IActionResult> Post([FromBody] User user)
		{
			return Ok();
		}

		[HttpPut]
		[Route("put")]
		public async Task<IActionResult> Put([FromBody] User user)
		{
			return Ok();
		}

		[HttpDelete]
		[Route("delete")]
		public async Task<IActionResult> Delete([FromBody] User user)
		{
			return Ok();
		}
	}
}

