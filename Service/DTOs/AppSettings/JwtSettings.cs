namespace Service.DTOs.AppSettings
{
	public class JwtSettings
	{
		public string Secret { get; private set; }
		public int ExpiresInHours { get; private set; }
		public string Issuer { get; private set; }
		public string Audience { get; private set; }
	}
}
