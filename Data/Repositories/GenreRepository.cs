using Data.Repositories.Interfaces;
using Domain;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class GenreRepository : IGenreRepository
	{
		private readonly IDataContext _dataContext;

		public GenreRepository(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<Genre> Get(int id)
		{
			return await _dataContext.Genres.FindAsync(id);
		}
	}
}
