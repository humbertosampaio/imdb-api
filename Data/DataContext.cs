using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			//	var administrator = new User(1, "admin", Role.Administrator);

			//	// Array de dados de entrada
			//	var actors = new Actor[50];
			//	for (int i = 1; i <= actors.Length; i++)
			//		actors[i - 1] = new Actor(i, $"Actor{i}");

			//	var directors = new Director[50];
			//	for (int i = 1; i <= directors.Length; i++)
			//		directors[i - 1] = new Director(i, $"Director{i}");

			//	var genres = new Genre[15];
			//	for (int i = 1; i <= genres.Length; i++)
			//		genres[i - 1] = new Genre(i, $"Genre{i}");

			//	var movies = new Movie[20];
			//	for (int i = 1; i <= movies.Length; i++)
			//		movies[i - 1] = new Movie(
			//			i,
			//			$"Movie{i}",
			//			genres[i / 2],
			//			new Actor[] { actors[(i * 2) - 1], actors[i * 2] },
			//			new Director[] { directors[(i * 2) - 1], directors[i * 2] }
			//		);

			//	modelBuilder.Entity<User>().HasData(administrator);
			//	modelBuilder.Entity<Actor>().HasData(actors);
			//	modelBuilder.Entity<Director>().HasData(directors);
			//	modelBuilder.Entity<Genre>().HasData(genres);
			//	modelBuilder.Entity<Movie>().HasData(movies);
		}

	public DbSet<Actor> Actors { get; set; }
		public DbSet<Director> Directors { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Rating> Ratings { get; set; }
		public DbSet<User> Users { get; set; }
	}
}