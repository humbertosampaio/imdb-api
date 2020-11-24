using System;
using System.Collections.Generic;

namespace Domain
{
	public class User
	{
		public User(int id, string login, RoleEnum role, bool active)
		{
			Id = id;
			Login = login;
			Role = role;
			Active = active;
		}

		public int Id { get; private set; }
		public string Login { get; private set; }
		public RoleEnum Role { get; private set; }
		public bool Active { get; private set; }
		public IEnumerable<Rating> Ratings { get; private set; }
	}

	public enum RoleEnum : short
	{
		Administrator = 1,
		BasicUser = 2
	}

	public struct Role
	{
		private readonly RoleEnum _roleEnum;
		private readonly string _roleString;

		private const string Administrator = "Administrator";
		private const string BasicUser = "BasicUser";

		private Role(RoleEnum roleEnum, string roleString)
		{
			_roleEnum = roleEnum;
			_roleString = roleString;
		}

		public static bool TryParse(string roleString, out Role role)
		{
			try
			{
				role = Parse(roleString);
				return true;
			}
			catch (Exception)
			{
				role = default;
				return false;
			}
		}

		public static Role Parse(RoleEnum roleEnum)
		{
			string roleString;
			if (roleEnum.Equals(RoleEnum.Administrator))
				roleString = Administrator;
			else if (roleEnum.Equals(RoleEnum.BasicUser))
				roleString = BasicUser;
			else
				throw new ApplicationException($"The role {roleEnum} is invalid");

			return new Role(roleEnum, roleString);
		}

		public static Role Parse(string roleString)
		{
			RoleEnum roleEnum;
			if (roleString.Equals(Administrator))
				roleEnum = RoleEnum.Administrator;
			else if (roleString.Equals(BasicUser))
				roleEnum = RoleEnum.BasicUser;
			else
				throw new ApplicationException($"The role {roleString} is invalid");

			return new Role(roleEnum, roleString);
		}

		public string AsString() => _roleString;

		public RoleEnum AsEnum() => _roleEnum;
	}
}
