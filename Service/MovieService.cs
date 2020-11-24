using Data.DTOs;
using Data.Repositories.Interfaces;
using Domain;
using Service.DTOs.Movie;
using Service.Factories.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
	public class MovieService : IMovieService
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IMovieFactory _movieFactory;

		public MovieService(IMovieRepository movieRepository, IMovieFactory movieFactory)
		{
			_movieRepository = movieRepository;
			_movieFactory = movieFactory;
		}

		public Task<IEnumerable<Movie>> Get(MovieFilterDto filter, int pageIndex = 0, int usersPerPage = 0)
		{
			throw new NotImplementedException();
		}

		public async Task AddAsync(MovieInputDto movieInputDto)
		{
			var movie = await _movieFactory.CreateAsync(movieInputDto);
			await _movieRepository.AddAsync(movie);
		}

		public Task AddRatingAsync(User user, int rating)
		{
			throw new NotImplementedException();
		}
	}
}
