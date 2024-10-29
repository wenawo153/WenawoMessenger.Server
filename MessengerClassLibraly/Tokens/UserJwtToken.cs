using MessengerClassLibraly.Tokens;

namespace WenawoMessenger.Server.AuthenticationService.Models
{
	public class UserJwtToken : JwtTokens
	{
		public string UserId { get; set; } = null!;
	}
}
