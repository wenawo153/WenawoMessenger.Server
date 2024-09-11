using System.ComponentModel.DataAnnotations;
using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.AuthenticationService.DBService.Models
{
	public class UserTokenDB
	{
		[Key]
		public string UserId { get; set; } = null!;
		public string AccessToken { get; set; } = null!; 
		public DateTime RefreshTokenCreated { get; set; }
		public DateTime RefreshTokenExpiration { get; set; }

		public UserToken ConvertToUserToken()
		{
			return new()
			{
				UserId = UserId,
				RefreshToken = new()
				{
					UserId = UserId,
					RefreshTokenExpiration = RefreshTokenExpiration,
					RefreshTokenCreated = RefreshTokenCreated
				},
				AccessToken = AccessToken
			};
		}
	}
}
