namespace Service.DTOs
{
	public readonly struct AuthenticationInputDto : IInputDto
	{
		public AuthenticationInputDto(string login, string password)
		{
			Login = login;
			Password = password;
		}

		public string Login { get; }
		public string Password { get; }

		public bool IsValid => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
	}
}
