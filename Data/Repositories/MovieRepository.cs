using Data.DTOs;
using Data.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<Movie> GetAsync(int id, bool asNoTracking)
		{
			IQueryable<Movie> movies = _dataContext.Movies;

			if (asNoTracking)
				movies = movies.AsNoTracking();

			return await movies.SingleAsync(movie => movie.Id.Equals(id));
		}

		public async Task<IEnumerable<Movie>> GetAsync(MovieFilterDto filter, int pageIndex = 0, int usersPerPage = 0)
		{
			throw new NotImplementedException();
		}

		public async Task AddAsync(Movie movie)
		{
			await _dataContext.Movies.AddAsync(movie);
			await _dataContext.SaveChangesAsync();
		}
	}
}
