using Flurl;
using Flurl.Http;
using MessengerClassLibraly.User;

namespace MessengerHttpServiceLibraly.HttpServices.UserService.Authorization
{
	public class AuthorizationService(HttpConfig HttpConfig) : IAuthorizationService
	{
		private readonly string link = HttpConfig.UserLink;

		public async Task<UserLogResponce> RegistrationAsync(UserRegModel userRegModel)
		{
			try
			{
				var url = new Url($"{link}/Authorization/Registration");

				var responce = await url.PostJsonAsync(userRegModel).ReceiveJson<UserLogResponce>();

				return responce;
			}
			catch
			{
				throw new Exception("Uses registration error");
			}
		}

		public async Task<UserLogResponce> LoginAsync(UserLogModel userLogModel)
		{
			try
			{
				var url = new Url($"{link}/Authorization/Login");

				var responce = await url.PostJsonAsync(userLogModel).ReceiveJson<UserLogResponce>();

				return responce;
			}
			catch
			{
				throw new Exception("Uses login error");
			}
		}
	}

}
