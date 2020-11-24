namespace Service.DTOs.AppSettings
{
	public class SystemDefaults
	{
		public AdminCredentials AdminCredentials { get; private set; }
		public string AdministatorRole { get; private set; }
		public string BasicUserRole { get; private set; }
	}

	public class AdminCredentials
	{
		public string Login { get; private set; }
		public string Password { get; private set; }
	}
}
