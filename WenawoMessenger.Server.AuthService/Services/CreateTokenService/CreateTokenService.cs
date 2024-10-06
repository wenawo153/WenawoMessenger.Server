using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WenawoMessenger.Server.AuthenticationService.DBService;
using WenawoMessenger.Server.AuthenticationService.DBService.Models;
using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.AuthenticationService.Services.CreateTokenService
{
	public class CreateTokenService(ApplicationDBContext applicationDBContext, IOptions<SecurityOptions> options) : ICreateTokenService
	{

		private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;
		private readonly SecurityOptions _options = options.Value;

		public async Task<UserJwtToken> CreateTokenAsync(string userId)
		{
			UserTokenDB? testUserDB = _applicationDBContext.UserKeys.FirstOrDefault((e) => e.UserId == userId);
			if (testUserDB != null)
			{
				_applicationDBContext.UserKeys.Remove(testUserDB);
			}

			try
			{
				var claimsIdentity = new List<Claim>{
				 	 new Claim("UserId", userId),
				};

				var now = DateTime.UtcNow;
				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtSecureKey));
				var jwt = new JwtSecurityToken(
					issuer: _options.Issuer,
					audience: _options.Audience,
					notBefore: now,
					claims: claimsIdentity,
					expires: now.Add(TimeSpan.FromMinutes(_options.ExpiresMinutesJwt)),
					signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha384)
					);
				var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

				var refreshToken = new RefreshToken(userId, now, now.Add(TimeSpan.FromDays(_options.ExpiresDaysRefresh)));

				var userKeys = new UserToken()
				{
					UserId = userId,
					AccessToken = encodedJwt,
					RefreshToken = refreshToken
				};

				var userKeysDb = userKeys.ConvertToUserTokenDB();

				await _applicationDBContext.AddAsync(userKeysDb);
				await _applicationDBContext.SaveChangesAsync();

				var userJwtToken = new UserJwtToken()
				{
					UserId = userId,
					AccessToken = encodedJwt,
					RefreshToken =  userKeys.RefreshToken.Token
				};

				return userJwtToken;
			}
			catch (ArgumentException)
			{
				throw new ArgumentException();
			}
		}
	}
}
