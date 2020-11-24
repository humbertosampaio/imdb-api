namespace Service.DTOs.User
{
	public readonly struct UserInputDto : IInputDto
	{
		public UserInputDto(string login, string password, string role)
		{
			Login = login;
			Password = password;
			Role = role;
		}

		public string Login { get; }
		public string Password { get; }
		public string Role { get; }

		public bool IsValid =>
			!string.IsNullOrEmpty(Login)
			&& !string.IsNullOrEmpty(Password)
			&& Domain.Role.TryParse(Role, out _);
	}
}
