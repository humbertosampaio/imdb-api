using Data.Repositories.Interfaces;
using Domain;
using Service.Factories.Interfaces;
using System.Threading.Tasks;

namespace Service.Factories
{
	public class RatingFactory : IRatingFactory
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IUserRepository _userRepository;

		public RatingFactory(IMovieRepository movieRepository, IUserRepository userRepository)
		{
			_movieRepository = movieRepository;
			_userRepository = userRepository;
		}

		public async Task<Rating> Create(int movieId, string userLogin, short rating)
		{
			return new Rating(
				0,
				await _userRepository.GetAsync(userLogin, asNoTracking: false),
				await _movieRepository.GetAsync(movieId, asNoTracking: false),
				rating
			);
		}
	}
}
