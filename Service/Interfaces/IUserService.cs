using Data.DTOs;
using Service.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
	public interface IUserService
	{
		Task<UserOutputDto> GetAsync(string login);

		Task<IEnumerable<UserOutputDto>> GetActiveBasicUsersAsync(PaginationDto paginationDto);

		Task AddAsync(UserInputDto userInputDto);

		Task UpdateAsync(int id, UserInputDto newUserInputDto);

		Task ActivateAsync(int id);

		Task DeactivateAsync(int id);
	}
}
