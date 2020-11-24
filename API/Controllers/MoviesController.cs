using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Movie;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IMovieService _movieService;

		public MoviesController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		/// <summary>
		/// Adiciona um novo filme.
		/// </summary>
		/// <param name="movieInputDto">Os dados do filme a ser inserido.</param>
		/// <response code="200">Filme adicionado com sucesso.</response>
		/// <response code="400">Corpo da requisição inválido.</response>
		/// <response code="500">Erro inesperado.</response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Post([FromBody] MovieInputDto movieInputDto)
		{
			try
			{
				if (!movieInputDto.IsValid)
					return BadRequest();

				await _movieService.AddAsync(movieInputDto);
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
		/// Adiciona uma avaliação para um filme.
		/// </summary>
		/// <param name="id">O id do filme.</param>
		/// <param name="rating">A nota para o filme.</param>
		/// <remarks>O valor da avaliação deve estar entre 0 e 4, inclusive.</remarks>
		/// <response code="200">Avaliação adicionada com sucesso.</response>
		/// <response code="400">Corpo da requisição inválido.</response>
		/// <response code="500">Erro inesperado.</response>
		[Authorize(Roles = "BasicUser")]
		[HttpPost("{id}/Rate")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Rate(int id, [FromQuery] short rating)
		{
			try
			{
				if (rating < 0 || rating > 4)
					return BadRequest("Rating should be between 0 and 4.");

				var userLogin = User.Identity.Name;
				await _movieService.RateAsync(id, userLogin, rating);

				return Ok();
			}
			catch (Exception)
			{
				return this.InternalServerError();
			}
		}
	}
}
