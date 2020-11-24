using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Data
{
	public class DataContext : DbContext, IDataContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			RunSeed(modelBuilder);
		}

		private void RunSeed(ModelBuilder modelBuilder)
		{
			var administrator = new User(1, "admin", RoleEnum.Administrator, true);

			var actors = new Actor[50];
			for (int i = 1; i <= actors.Length; i++)
				actors[i - 1] = new Actor(i, $"Actor{i}");

			var directors = new Director[50];
			for (int i = 1; i <= directors.Length; i++)
				directors[i - 1] = new Director(i, $"Director{i}");

			var genres = new Genre[20];
			for (int i = 1; i <= genres.Length; i++)
				genres[i - 1] = new Genre(i, $"Genre{i}");

			var movies = new dynamic[20];
			for (int i = 1; i <= movies.Length; i++)
				movies[i - 1] = new
				{
					Id = i,
					Name = $"Movie{i}",
					GenreId = genres[i - 1].Id
				};

			var actorsMovies = new object[]
			{
				new { ActorsId = directors[0].Id, MoviesId = movies[0].Id },
				new { ActorsId = directors[1].Id, MoviesId = movies[0].Id },
				new { ActorsId = directors[2].Id, MoviesId = movies[1].Id },
				new { ActorsId = directors[3].Id, MoviesId = movies[1].Id },
			};

			var directorsMovies = new object[]
			{
				new { DirectorsId = directors[0].Id, MoviesId = movies[0].Id },
				new { DirectorsId = directors[1].Id, MoviesId = movies[0].Id },
				new { DirectorsId = directors[2].Id, MoviesId = movies[1].Id },
				new { DirectorsId = directors[3].Id, MoviesId = movies[1].Id },
			};

			modelBuilder.Entity<User>().HasData(administrator);
			modelBuilder.Entity<Actor>().HasData(actors);
			modelBuilder.Entity<Director>().HasData(directors);
			modelBuilder.Entity<Genre>().HasData(genres);
			modelBuilder.Entity<Movie>().HasData(movies);
			modelBuilder.Entity("ActorMovie").HasData(actorsMovies);
			modelBuilder.Entity("DirectorMovie").HasData(directorsMovies);
		}

		public Task SaveChangesAsync()
		{
			return Task.Run(() => base.SaveChangesAsync());
		}

		public DbSet<Actor> Actors { get; set; }
		public DbSet<Director> Directors { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Rating> Ratings { get; set; }
		public DbSet<User> Users { get; set; }
	}
}