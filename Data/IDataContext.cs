using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public interface IDataContext
	{
		DbSet<Actor> Actors { get; set; }
		DbSet<Director> Directors { get; set; }
		DbSet<Genre> Genres { get; set; }
		DbSet<Movie> Movies { get; set; }
		DbSet<Rating> Ratings { get; set; }
		DbSet<User> Users { get; set; }
	}
}