using Data.DTOs;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetAsync(int id);

		Task<User> GetAsync(string login);

		Task<IEnumerable<User>> GetActiveBasicUsersAsync(PaginationDto paginationDto);

		Task AddAsync(User user);

		Task UpdateAsync(User user);
	}
}
