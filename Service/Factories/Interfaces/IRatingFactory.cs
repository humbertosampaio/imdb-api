using Domain;
using System.Threading.Tasks;

namespace Service.Factories.Interfaces
{
	public interface IRatingFactory
	{
		Task<Rating> Create(int movieId, string userLogin, short rating);
	}
}
