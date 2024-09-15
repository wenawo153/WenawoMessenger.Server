using MessengerClassLibraly.User;

namespace MessengerHttpServiceLibraly.HttpServices.UserService.Authorization
{
	public interface IAuthorizationService
	{
		Task<UserLogResponce> LoginAsync(UserLogModel userLogModel);
		Task<UserLogResponce> RegistrationAsync(UserRegModel userRegModel);
	}
}