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
				var url = new Url($"{link}/authorization/registration");

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
				var queryParams = new Dictionary<string, string>
				{
					{"email", userLogModel.Email},
					{"password", userLogModel.Password }
				};

				var url = new Url($"{link}/authorization/login").SetQueryParams(queryParams);

				var responce = await url.GetJsonAsync<UserLogResponce>();

				return responce;
			}
			catch
			{
				throw new Exception("Uses login error");
			}
		}
	}

}
