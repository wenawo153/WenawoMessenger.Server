using System.Security.Cryptography;
using System.Text;

namespace WenawoMessenger.Server.AuthenticationService.Models
{
	public class RefreshToken
	{
		public string UserId { get; set; } = null!;
		public string Token { get; set; } = null!;
		public DateTime RefreshTokenCreated { get; set; }
		public DateTime RefreshTokenExpiration { get; set; }

		public RefreshToken(string userId, string token, DateTime refreshTokenCreated, DateTime refreshTokenExpiration) 
		{
			UserId = userId;
			Token = token;
			RefreshTokenCreated = refreshTokenCreated;
			RefreshTokenExpiration = refreshTokenExpiration;
		}
		
		public RefreshToken(string userId, DateTime refreshTokenCreated, DateTime refreshTokenExpiration) 
		{
			UserId = userId;
			Token = GenerateRefreshToken();
			RefreshTokenCreated = refreshTokenCreated;
			RefreshTokenExpiration = refreshTokenExpiration;
		}


		private static string GenerateRefreshToken()
		{
			var randomNumber = new byte[64];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
	}

}
