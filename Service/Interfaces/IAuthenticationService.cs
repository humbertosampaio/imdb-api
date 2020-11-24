using Service.DTOs;
using Service.DTOs.User;
using System.Threading.Tasks;

namespace Service.Interfaces
{
	public interface IAuthenticationService
	{
		Task<string> GenerateJwt(string userLogin);

		/// <exception cref="System.ApplicationException">If any error occurs while adding the user to Identity.</exception>
		Task RegisterNewUserAsync(UserInputDto userInputDto);

		Task<bool> Login(AuthenticationInputDto authenticationInputDto);
	}
}