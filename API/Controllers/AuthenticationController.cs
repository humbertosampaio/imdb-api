using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : BaseApiController
	{
		private readonly IAuthenticationService _authenticationService;

		public AuthenticationController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] AuthenticationInputDto authenticationDto)
		{
			try
			{
				if (!authenticationDto.IsValid)
					return BadRequest();

				var success = await _authenticationService.Login(authenticationDto);

				if (success)
				{
					var token = await _authenticationService.GenerateJwt(authenticationDto.Login);
					return Ok(token);
				}
				else
					return Unauthorized();
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
