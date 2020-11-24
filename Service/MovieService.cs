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
		private readonly IRatingRepository _ratingRepository;
		private readonly IUserRepository _userRepository;

		private readonly IMovieFactory _movieFactory;
		private readonly IRatingFactory _ratingFactory;

		public MovieService(
			IMovieRepository movieRepository,
			IRatingRepository ratingRepository,
			IUserRepository userRepository,
			IMovieFactory movieFactory,
			IRatingFactory ratingFactory)
		{
			_movieRepository = movieRepository;
			_ratingRepository = ratingRepository;
			_userRepository = userRepository;
			_movieFactory = movieFactory;
			_ratingFactory = ratingFactory;
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

		public async Task RateAsync(int movieId, string userLogin, short rating)
		{
			var newRating = await _ratingFactory.Create(movieId, userLogin, rating);
			await _ratingRepository.AddAsync(newRating);
		}
	}
}
