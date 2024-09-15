namespace MessengerHttpServiceLibraly.HttpServices.AuthenticationService
{
	public interface IAuthenticationService
	{
		Task<string> CreateTokenAsync(string userId);
		Task<string> RefreshTokenAsync(string userId);
	}
}