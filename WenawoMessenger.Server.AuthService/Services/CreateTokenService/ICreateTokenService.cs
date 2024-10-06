using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.AuthenticationService.Services.CreateTokenService
{
	public interface ICreateTokenService
	{
		public Task<UserJwtToken> CreateTokenAsync(string userId);
	}
}
