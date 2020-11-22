using System.Collections.Generic;

namespace Domain.Repositories.Filters
{
	public readonly struct MovieFilterDto
	{
		public MovieFilterDto(
			string movieName = null,
			IEnumerable<string> directorNames = null,
			IEnumerable<string> genres = null,
			IEnumerable<string> actorNames = null)
		{
			MovieName = movieName;
			DirectorNames = directorNames;
			Genres = genres;
			ActorNames = actorNames;
		}

		public string MovieName { get; }

		public IEnumerable<string> DirectorNames { get; }

		public IEnumerable<string> Genres { get; }

		public IEnumerable<string> ActorNames { get; }
	}
}
