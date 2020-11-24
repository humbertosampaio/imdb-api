namespace Service.DTOs
{
	public struct AuthenticationInputDto : IInputDto
	{
		public string Login { get; set; }
		public string Password { get; set; }

		public bool IsValid => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
	}
}
