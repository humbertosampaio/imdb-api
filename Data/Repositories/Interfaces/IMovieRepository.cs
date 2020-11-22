using Data.Repositories.Filters;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
	public interface IMovieRepository
	{
		Task<IEnumerable<Movie>> Get(MovieFilterDto filter, int pageIndex = 0, int usersPerPage = 0);

		Task Insert(Movie movie);

		Task AddRating(User user, int rating);
	}
}
