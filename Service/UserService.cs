using Data.Repositories.Interfaces;
using Service.DTOs.User;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<IEnumerable<UserOutputDto>> GetAll()
		{
			var users = await _userRepository.GetAll();
			return users.Select(user => new UserOutputDto(user));
		}
	}
}
