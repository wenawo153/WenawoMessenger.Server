using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WenawoMessenger.Server.AuthenticationService.DBService;
using WenawoMessenger.Server.AuthenticationService.DBService.Models;
using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.AuthenticationService.Services.RefreshTokenService
{
	public class RefreshTokenService(ApplicationDBContext applicationDBContext, IOptions<SecurityOptions> options) : IRefreshTokenService
	{
		private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;
		private readonly SecurityOptions _options = options.Value;

		public async Task<UserJwtToken> RefreshTokenAsync(string userId, string refreshToken)
		{
			UserTokenDB lastUserKeysDB = _applicationDBContext.UserKeys.FirstOrDefault((e) => e.UserId == userId)!;
			UserToken? lastUserKeys = lastUserKeysDB.ConvertToUserToken();
			var now = DateTime.UtcNow;
			if (lastUserKeys.RefreshToken.Token == refreshToken && lastUserKeys != null && lastUserKeys.RefreshToken.RefreshTokenExpiration > now)
			{
				try
				{
					var claimsIdentity = new List<Claim>{
				 	 new ("userId", userId),
				};

					var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtSecureKey));
					var jwt = new JwtSecurityToken(
						issuer: "WenawoMessenger.Server",
						audience: "WenawoMessenger.Client",
						notBefore: now,
						claims: claimsIdentity,
						expires: now.Add(TimeSpan.FromMinutes(_options.ExpiresMinutesJwt)),
						signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
						);
					var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

					var newRefreshToken = new RefreshToken(userId, now, now.Add(TimeSpan.FromDays(_options.ExpiresDaysRefresh)));

					var userKeys = new UserToken()
					{
						UserId = userId,
						AccessToken = encodedJwt,
						RefreshToken = newRefreshToken
					};

					_applicationDBContext.UserKeys.Remove(lastUserKeysDB);
					await _applicationDBContext.UserKeys.AddAsync(userKeys.ConvertToUserTokenDB());
					await _applicationDBContext.SaveChangesAsync();

					var userJwtToken = new UserJwtToken()
					{
						UserId = userId,
						AccessToken = encodedJwt,
						RefreshToken = newRefreshToken.Token
					};

					return userJwtToken;
				}
				catch (ArgumentException)
				{
					throw new ArgumentException();
				}
			}
			else
			{
				throw new Exception("Refresh token has expired");
			}
		}
	}
}
