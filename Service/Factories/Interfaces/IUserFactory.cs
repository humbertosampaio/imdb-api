using Domain;
using Service.DTOs.User;

namespace Service.Factories.Interfaces
{
	public interface IUserFactory
	{
		User Create(UserInputDto dto);
	}
}