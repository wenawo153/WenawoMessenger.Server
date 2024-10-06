using WenawoMessenger.Server.AuthenticationService.Models;

namespace MessengerHttpServiceLibraly.HttpServices.AuthenticationService
{
	public interface IAuthenticationService
	{
		Task<UserJwtToken> CreateTokenAsync(string userId);
		Task<UserJwtToken> RefreshTokenAsync(string userId, string refreshToken);
	}
}