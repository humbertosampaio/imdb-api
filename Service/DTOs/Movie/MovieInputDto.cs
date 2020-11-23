using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Service.DTOs.Movie
{
	public class MovieInputDto : IInputDto
	{
		[JsonConstructor]
		public MovieInputDto(
			string name,
			int genreId,
			IEnumerable<int> actorsIds,
			IEnumerable<int> directorsIds)
		{
			Name = name;
			GenreId = genreId;
			ActorsIds = actorsIds;
			DirectorsIds = directorsIds;
		}

		public string Name { get; }
		public int GenreId { get; }
		public IEnumerable<int> ActorsIds { get; }
		public IEnumerable<int> DirectorsIds { get; }

		public bool IsValid => !string.IsNullOrEmpty(Name)
			&& GenreId > 0
			&& ActorsIds.Count() > 0
			&& DirectorsIds.Count() > 0;
	}
}
