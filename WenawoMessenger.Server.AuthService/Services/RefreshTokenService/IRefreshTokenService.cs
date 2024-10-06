using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.AuthenticationService.Services.RefreshTokenService
{
	public interface IRefreshTokenService
	{
		public Task<UserJwtToken> RefreshTokenAsync(string userId, string refreshToken);
	}
}
