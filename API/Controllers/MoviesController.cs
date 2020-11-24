using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Movie;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : BaseApiController
	{
		private readonly IMovieService _movieService;

		public MoviesController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}

		[HttpPost]
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
				return InternalServerError(e.Message);
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}
	}
}
