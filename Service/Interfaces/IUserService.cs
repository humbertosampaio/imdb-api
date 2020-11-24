using Service.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserOutputDto>> GetAll();

		Task AddAsync(UserInputDto userInputDto);

		Task UpdateAsync(int id, UserInputDto newUserInputDto);
	}
}
