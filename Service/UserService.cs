using Data.Repositories.Interfaces;
using Service.DTOs.User;
using Service.Factories.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IAuthenticationService _authenticationService;
		private readonly IUserFactory _userFactory;

		public UserService(
			IAuthenticationService authenticationService,
			IUserRepository userRepository,
			IUserFactory userFactory)
		{
			_authenticationService = authenticationService;
			_userRepository = userRepository;
			_userFactory = userFactory;
		}

		public async Task<IEnumerable<UserOutputDto>> GetAll()
		{
			var users = await _userRepository.GetAll();
			return users.Select(user => new UserOutputDto(user));
		}

		public async Task AddAsync(UserInputDto userInputDto)
		{
			await _authenticationService.RegisterNewUserAsync(userInputDto);

			var user = _userFactory.Create(userInputDto);
			await _userRepository.AddAsync(user);
		}

		public async Task UpdateAsync(int id, UserInputDto newUserInputDto)
		{
			var newUser = _userFactory.Create(newUserInputDto, id);
			await _userRepository.UpdateAsync(newUser);
		}

		public async Task DeactivateAsync(int id)
		{
			var existingUser = await _userRepository.GetAsync(id);
			existingUser.Deactivate();
			await _userRepository.UpdateAsync(existingUser);
		}

		public async Task ActivateAsync(int id)
		{
			var existingUser = await _userRepository.GetAsync(id);
			existingUser.Activate();
			await _userRepository.UpdateAsync(existingUser);
		}
	}
}
