using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
	public interface IDirectorRepository
	{
		Task<IEnumerable<Director>> Get(IEnumerable<int> ids);
	}
}