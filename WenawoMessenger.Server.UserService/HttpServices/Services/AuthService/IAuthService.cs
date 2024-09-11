using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.UserService.HttpServices.Services.AuthService
{
	public interface IAuthService
	{
		public Task<string> CreateTokenAsync(string userId);
		public Task<string> RefreshTokenAsync(string userId);
	}
} 