using Data.DTOs;
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

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] UserInputDto userDto)
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

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] UserInputDto newUserDto)
		{
			try
			{
				if (!newUserDto.IsValid)
					return BadRequest();

				await _userService.UpdateAsync(id, newUserDto);

				return Ok();
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}

		[HttpPatch("Activate/{id}")]
		public async Task<IActionResult> Activate(int id)
		{
			try
			{
				await _userService.ActivateAsync(id);
				return Ok();
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}

		[HttpPatch("Deactivate/{id}")]
		public async Task<IActionResult> Deactivate(int id)
		{
			try
			{
				await _userService.DeactivateAsync(id);
				return Ok();
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}

		[HttpGet("ActiveBasicUsers")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> GetActiveBasicUsers(PaginationDto paginationDto)
		{
			try
			{
				var users = await _userService.GetActiveBasicUsersAsync(paginationDto);
				return Ok(users);
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}
	}
}
