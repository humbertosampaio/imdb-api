using System.Collections.Generic;
using System.Linq;

namespace Service.DTOs.Movie
{
	public class MovieInputDto : IInputDto
	{
		public string Name { get; set; }
		public int GenreId { get; set; }
		public IEnumerable<int> ActorsIds { get; set; }
		public IEnumerable<int> DirectorsIds { get; set; }

		public bool IsValid => !string.IsNullOrEmpty(Name)
			&& GenreId > 0
			&& ActorsIds.Count() > 0
			&& DirectorsIds.Count() > 0;
	}
}
