using System.Collections.Generic;

namespace Domain
{
	public class Movie
	{
		public Movie(
			int id,
			string name,
			Genre genre,
			ICollection<Actor> actors,
			ICollection<Director> directors)
			: this(id, name)
		{
			Genre = genre;
			Actors = actors;
			Directors = directors;
		}

		private Movie(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public Genre Genre { get; private set; }
		public ICollection<Actor> Actors { get; private set; }
		public ICollection<Director> Directors { get; private set; }
		public ICollection<Rating> Ratings { get; private set; }
	}
}
