namespace WenawoMessenger.Server.AuthenticationService.Models
{
	public class SecurityOptions
	{
		public string JwtSecureKey { get; set; } = null!;
		public string RefreshSecureKey { get; set; } = null!;
		public int ExpiresMinutesJwt { get; set; }
		public int ExpiresDaysRefresh { get; set; }
		public string Issuer { get; set; } = null!;
		public string Audience { get; set; } = null!;
	}
}
