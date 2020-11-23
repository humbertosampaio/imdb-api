using Data.Repositories.Interfaces;
using Domain;
using Service.DTOs.Movie;
using Service.Factories.Interfaces;
using System.Threading.Tasks;

namespace Service.Factories
{
	public class MovieFactory : IMovieFactory
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IActorRepository _actorRepository;
		private readonly IDirectorRepository _directorRepository;

		public MovieFactory(IGenreRepository genreRepository, IActorRepository actorRepository, IDirectorRepository directorRepository)
		{
			_genreRepository = genreRepository;
			_actorRepository = actorRepository;
			_directorRepository = directorRepository;
		}

		public async Task<Movie> CreateAsync(MovieInputDto dto)
		{
			return new Movie(
				0,
				dto.Name,
				await _genreRepository.Get(dto.GenreId),
				await _actorRepository.Get(dto.ActorsIds),
				await _directorRepository.Get(dto.DirectorsIds),
				null
			);
		}
	}
}
