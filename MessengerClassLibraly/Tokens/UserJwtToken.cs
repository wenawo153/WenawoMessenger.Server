namespace WenawoMessenger.Server.AuthenticationService.Models
{
	public class UserJwtToken
	{
		public string UserId { get; set; } = null!;
		public string AccessToken { get; set; } = null!;
	}
}
