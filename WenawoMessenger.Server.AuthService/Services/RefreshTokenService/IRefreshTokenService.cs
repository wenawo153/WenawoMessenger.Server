using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.AuthenticationService.Services.RefreshTokenService
{
	public interface IRefreshTokenService
	{
		public Task<string> RefreshTokenAsync(string userId);
	}
}
