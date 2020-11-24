using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationService _authenticationService;

		public AuthenticationController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		/// <summary>
		/// Efetua o login de um usuário cadastrado.
		/// </summary>
		/// <param name="authenticationDto">Os dados de login do usuário.</param>
		/// <returns>O token de autenticação.</returns>
		/// <response code="200">Usuário autenticado com sucesso.</response>
		/// <response code="400">Corpo da requisição inválido.</response>
		/// <response code="500">Erro inesperado.</response>
		[HttpPost("Login")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
				return this.InternalServerError(e.Message);
			}
			catch (Exception)
			{
				return this.InternalServerError();
			}
		}
	}
}
