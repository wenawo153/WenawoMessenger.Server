using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.AuthenticationService.Services.CreateTokenService
{
	public interface ICreateTokenService
	{
		public Task<string> CreateTokenAsync(string userId);
	}
}
