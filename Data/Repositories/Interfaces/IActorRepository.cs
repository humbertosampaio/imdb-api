using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
	public interface IActorRepository
	{
		Task<IEnumerable<Actor>> Get(IEnumerable<int> ids);
	}
}