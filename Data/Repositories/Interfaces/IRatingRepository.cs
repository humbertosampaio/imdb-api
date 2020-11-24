using Domain;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
	public interface IRatingRepository
	{
		Task AddAsync(Rating rating);
	}
}
