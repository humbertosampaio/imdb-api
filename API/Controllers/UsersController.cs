using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.User;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : BaseApiController
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Get()
		{
			var users = await _userService.GetAll();
			return Ok(users);
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] UserInputDto userDto)
		{
			try
			{
				if (!userDto.IsValid)
					return BadRequest();

				await _userService.AddAsync(userDto);

				return Ok();
			}
			catch (ApplicationException e)
			{
				return InternalServerError(e.Message);
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}
	}
}
