using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		/// <summary>
		/// Adiciona um novo usuário.
		/// </summary>
		/// <param name="userDto">Os dados do usuário.</param>
		/// <response code="200">Usuário adicionado com sucesso.</response>
		/// <response code="400">Corpo da requisição inválido.</response>
		/// <response code="500">Erro inesperado.</response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
				return this.InternalServerError(e.Message);
			}
			catch (Exception)
			{
				return this.InternalServerError();
			}
		}

		/// <summary>
		/// Edita um usuário existente.
		/// </summary>
		/// <param name="id">O id do usuário.</param>
		/// <param name="newUserDto">Os novos dados do usuário.</param>
		/// <response code="200">Usuário editado com sucesso.</response>
		/// <response code="400">Corpo da requisição inválido.</response>
		/// <response code="500">Erro inesperado.</response>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
				return this.InternalServerError();
			}
		}

		/// <summary>
		/// Define um usuário existente como ativo.
		/// </summary>
		/// <param name="id">O id do usuário.</param>
		/// <response code="200">Usuário ativado com sucesso.</response>
		/// <response code="400">Id informado for menor do que zero.</response>
		/// <response code="500">Nenhum usuário encontrado com o id <paramref name="id"/>, ou erro inesperado.</response>
		[HttpPatch("Activate/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Activate(int id)
		{
			try
			{
				if (id < 1)
					return BadRequest("User id must be greater than 0.");

				await _userService.ActivateAsync(id);
				return Ok();
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

		/// <summary>
		/// Desativa um usúário.
		/// </summary>
		/// <param name="id">O id do usuário</param>
		/// <response code="200">Usuário ativado com sucesso.</response>
		/// <response code="400">Id informado for menor do que zero.</response>
		/// <response code="500">Nenhum usuário encontrado com o id <paramref name="id"/>, ou erro inesperado.</response>
		[HttpPatch("Deactivate/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Deactivate(int id)
		{
			try
			{
				if (id < 1)
					return BadRequest("User id must be greater than 0.");

				await _userService.DeactivateAsync(id);
				return Ok();
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

		/// <summary>
		/// Obtém uma coleção paginada contendo os usuários não-administradores ativos.
		/// </summary>
		/// <param name="paginationDto">Configuração da paginação, se desejada.</param>
		/// <returns></returns>
		/// <response code="200">A coleção de usuários não-administradores ativos.</response>
		/// <response code="500">Erro inesperado.</response>
		[HttpGet("ActiveBasicUsers")]
		[Authorize(Roles = "Administrator")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetActiveBasicUsers(PaginationDto paginationDto)
		{
			try
			{
				var users = await _userService.GetActiveBasicUsersAsync(paginationDto);
				return Ok(users);
			}
			catch (Exception)
			{
				return this.InternalServerError();
			}
		}
	}
}
