using System.Collections.Generic;

namespace Domain
{
	public class Movie
	{
		public Movie(
			int id,
			string name,
			Genre genre,
			IEnumerable<Actor> actors,
			IEnumerable<Director> directors,
			IEnumerable<Rating> ratings)
			: this(id, name)
		{
			Genre = genre;
			Actors = actors;
			Directors = directors;
			Ratings = ratings;
		}

		public Movie(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public Genre Genre { get; private set; }
		public IEnumerable<Actor> Actors { get; private set; }
		public IEnumerable<Director> Directors { get; private set; }
		public IEnumerable<Rating> Ratings { get; private set; }
	}
}
