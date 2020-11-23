using System.Collections.Generic;

namespace Domain
{
	public class Genre
	{
		public Genre(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public IEnumerable<Movie> Movies { get; set; }
	}
}
