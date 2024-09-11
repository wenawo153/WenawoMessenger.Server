using System.Text;

namespace WenawoMessenger.Server.AuthenticationService.Models
{
	public class RefreshToken
	{
		public string UserId { get; set; } = null!;
		public DateTime RefreshTokenCreated { get; set; }
		public DateTime RefreshTokenExpiration { get; set; }
	}
}
