using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAll();

		Task<User> GetAsync(string login);

		Task AddAsync(User user);

		Task Deactivate(User user);

		Task<IEnumerable<User>> GetActiveBasicUsers(int pageIndex = 0, int usersPerPage = 0);
	}
}
