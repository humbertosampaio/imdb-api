using Domain;
using Service.DTOs.User;
using Service.Factories.Interfaces;
using System;

namespace Service.Factories
{
	public class UserFactory : IUserFactory
	{
		public User Create(UserInputDto dto, int id = 0)
		{
			RoleEnum role;
			if (dto.Role.Equals("Administrator", StringComparison.InvariantCultureIgnoreCase))
				role = RoleEnum.Administrator;
			else if (dto.Role.Equals("BasicUser", StringComparison.InvariantCultureIgnoreCase))
				role = RoleEnum.BasicUser;
			else
				throw new ApplicationException($"The {dto.Role} role is invalid.");

			return new User(id, dto.Login, role, true);
		}
	}
}
