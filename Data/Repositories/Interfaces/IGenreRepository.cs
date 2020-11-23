using Domain;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
	public interface IGenreRepository
	{
		Task<Genre> Get(int id);
	}
}