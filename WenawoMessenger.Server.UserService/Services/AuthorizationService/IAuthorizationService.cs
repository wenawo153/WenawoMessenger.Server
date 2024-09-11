using MessengerClassLibraly.User;

namespace WenawoMessenger.Server.UserService.Services.AuthorizationService
{
	public interface IAuthorizationService
    {
        public Task<UserLogResponce> RegistrationAsync(UserRegModel userRegData);
        public Task<UserLogResponce> LoginAsync(UserLogModel userLogData);
    }
}
