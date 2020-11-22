using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<User> Get(int id);

		Task Insert(User user);

		Task Deactivate(User user);

		Task<IEnumerable<User>> GetActiveBasicUsers(int pageIndex = 0, int usersPerPage = 0);
	}
}
