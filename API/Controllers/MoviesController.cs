using Microsoft.AspNetCore.Authorization;
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
	public class MoviesController : BaseApiController
	{
		private readonly IMovieService _movieService;

		public MoviesController(IMovieService movieService)
		{
			_movieService = movieService;
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

		[Authorize(Roles = "BasicUser")]
		[HttpPost("{id}/Rate")]
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
				return InternalServerError();
			}
		}
	}
}
