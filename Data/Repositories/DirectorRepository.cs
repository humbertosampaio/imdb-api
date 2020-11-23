using Data.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class DirectorRepository : IDirectorRepository
	{
		private readonly IDataContext _dataContext;

		public DirectorRepository(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<IEnumerable<Director>> Get(IEnumerable<int> ids)
		{
			return await _dataContext.Directors
				.Where(actor => ids.Contains(actor.Id))
				.ToListAsync();
		}
	}
}
