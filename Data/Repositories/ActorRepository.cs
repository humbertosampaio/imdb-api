using Data.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class ActorRepository : IActorRepository
	{
		private readonly IDataContext _dataContext;

		public ActorRepository(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<IEnumerable<Actor>> Get(IEnumerable<int> ids)
		{
			return await _dataContext.Actors
				.Where(actor => ids.Contains(actor.Id))
				.ToListAsync();
		}
	}
}
