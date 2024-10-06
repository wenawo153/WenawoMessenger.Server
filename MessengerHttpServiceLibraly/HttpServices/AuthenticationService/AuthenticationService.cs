using Flurl;
using Flurl.Http;
using WenawoMessenger.Server.AuthenticationService.Models;

namespace MessengerHttpServiceLibraly.HttpServices.AuthenticationService
{
	public class AuthenticationService(HttpConfig HttpConfig) : IAuthenticationService
	{
		private readonly string link = HttpConfig.AuthenticationLink;

		public async Task<UserJwtToken> CreateTokenAsync(string userId)
		{
			try
			{
				var url = new Url($"{link}/authentication/CreateToken").SetQueryParam("userId", userId);

				var result = await url.GetJsonAsync<UserJwtToken>();
				if (result != null) return result;
				else throw new Exception("Nullable result");
			}
			catch { throw new Exception("Create token failed"); }
		}

		public async Task<UserJwtToken> RefreshTokenAsync(string userId, string refreshToken)
		{
			try
			{
				Dictionary<string, string> queryParams = new()
				{
					{"userId", userId},
					{"refreshToken", refreshToken }
				};

				var url = new Url($"{link}/refreshtoken/RefreshToken").SetQueryParams(queryParams);

				var result = await url.GetJsonAsync<UserJwtToken>();
				if (result != null) return result;
				else throw new Exception("Nullable result");
			}
			catch { throw new Exception("Create token failed"); }
		}
	}
}

