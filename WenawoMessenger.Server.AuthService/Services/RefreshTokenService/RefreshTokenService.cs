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

		public async Task<string> RefreshTokenAsync(string userId)
		{
			UserTokenDB lastUserKeysDB = _applicationDBContext.UserKeys.FirstOrDefault((e) => e.UserId == userId)!;
			UserToken? lastUserKeys = lastUserKeysDB.ConvertToUserToken();
			var now = DateTime.UtcNow;
			if (lastUserKeys != null && lastUserKeys.RefreshToken.RefreshTokenExpiration > now)
			{
				try
				{
					var claimsIdentity = new List<Claim>{
				 	 new ("UserId", userId),
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

					var refreshToken = new RefreshToken()
					{
						UserId = userId,
						RefreshTokenCreated = now,
						RefreshTokenExpiration = now.Add(TimeSpan.FromDays(_options.ExpiresDaysRefresh))
					};

					//var refreshToken = new JwtSecurityToken(
					//	issuer: _options.Issuer,
					//	audience: _options.Audience,
					//	notBefore: now,
					//	claims: claimsIdentity,
					//	expires: now.Add(TimeSpan.FromDays(_options.ExpiresDaysRefresh)),
					//	signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
					//var encodedRefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken);

					var userKeys = new UserToken()
					{
						UserId = userId,
						AccessToken = encodedJwt,
						RefreshToken = refreshToken
					};

					_applicationDBContext.UserKeys.Remove(lastUserKeysDB);
					await _applicationDBContext.UserKeys.AddAsync(userKeys.ConvertToUserTokenDB());
					await _applicationDBContext.SaveChangesAsync();

					return encodedJwt;
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
