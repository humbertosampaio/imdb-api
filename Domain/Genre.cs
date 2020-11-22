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
		public ICollection<Movie> Movies { get; set; }
	}
}
