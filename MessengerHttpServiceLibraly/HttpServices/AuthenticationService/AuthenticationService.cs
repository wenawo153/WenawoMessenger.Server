using Flurl;
using Flurl.Http;

namespace MessengerHttpServiceLibraly.HttpServices.AuthenticationService
{
	public class AuthenticationService(HttpConfig HttpConfig) : IAuthenticationService
	{
		private readonly string link = HttpConfig.AuthenticationLink;

		public async Task<string> CreateTokenAsync(string userId)
		{
			try
			{
				var url = new Url($"{link}/authentication/CreateToken").SetQueryParam("userId", userId);

				var result = await url.GetStringAsync();
				if (result != null) return result;
				else throw new Exception("Nullable result");
			}
			catch { throw new Exception("Create token failed"); }
		}

		public async Task<string> RefreshTokenAsync(string userId)
		{
			try
			{
				var url = new Uri($"{link}/refreshtoken/RefreshToken").SetQueryParam("userId", userId);

				var result = await url.GetStringAsync();
				if (result != null) return result;
				else throw new Exception("Nullable result");
			}
			catch { throw new Exception("Create token failed"); }
		}
	}
}

