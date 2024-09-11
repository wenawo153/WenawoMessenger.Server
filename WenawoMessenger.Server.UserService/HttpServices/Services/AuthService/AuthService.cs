using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.UserService.HttpServices.Services.AuthService
{
	public class AuthService(IOptions<HttpConfig> options) : IAuthService
	{
		private readonly string authLink = options.Value.AuthenticationLink;
		public async Task<string> CreateTokenAsync(string userId)
		{
			try
			{
				var url = new Url($"{authLink}/authentication/CreateToken").SetQueryParam("userId", userId);

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
				var url = new Url($"{authLink}/refreshtoken/RefreshToken").SetQueryParam("userId", userId);

				var result = await url.GetStringAsync();
				if (result != null) return result;
				else throw new Exception("Nullable result");
			}
			catch { throw new Exception("Create token failed"); }
		}
	}
}
