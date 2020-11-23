using Data.Repositories.Filters;
using Data.Repositories.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class MovieRepository : IMovieRepository
	{
		private readonly IDataContext _dataContext;

		public MovieRepository(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<IEnumerable<Movie>> Get(MovieFilterDto filter, int pageIndex = 0, int usersPerPage = 0)
		{
			throw new NotImplementedException();
		}

		public async Task AddAsync(Movie movie)
		{
			await _dataContext.Movies.AddAsync(movie);
			await _dataContext.SaveChangesAsync();
		}

		public async Task AddRating(User user, int rating)
		{
			throw new NotImplementedException();
		}
	}
}
