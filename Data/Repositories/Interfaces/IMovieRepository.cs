using Data.DTOs;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
	public interface IMovieRepository
	{
		Task<Movie> GetAsync(int id, bool asNoTracking);

		Task<IEnumerable<Movie>> GetAsync(MovieFilterDto filter, int pageIndex = 0, int usersPerPage = 0);

		Task AddAsync(Movie movie);
	}
}
