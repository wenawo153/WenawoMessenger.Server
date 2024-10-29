using MessengerClassLibraly.User;

namespace WenawoMessenger.Server.UserService.Services.UserDataService
{
	public interface IUserDataService
	{
		Task<PersonUserGetData> EditUserDataAsync(EditUserModel editUserModel);
		Task<PersonUserGetData> GetPersonUserGetDataAsync(string userId);
		Task<UserViewData> GetUserViewDataAsync(string userId);
	}
}