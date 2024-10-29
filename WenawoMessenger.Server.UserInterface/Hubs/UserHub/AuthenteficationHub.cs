using MessengerClassLibraly.Tokens;
using MessengerClassLibraly.User;
using MessengerHttpServiceLibraly.HttpServices.AuthenticationService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WenawoMessenger.Server.UserInterface.Services.JwtService;

namespace WenawoMessenger.Server.UserInterface.Hubs.UserHub
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class AuthenteficationHub(IAuthenticationService authenticationService) : Hub
	{
		private readonly IAuthenticationService _authenticationService = authenticationService;
		
		public async Task RefreshTokens(JwtTokens tokens)
		{
			try
			{
				var claimService = new GetClaim();
				var userId = claimService.GetJWTTokenClaim(tokens.AccessToken, "userId");

				var newToken = await _authenticationService.RefreshTokenAsync(userId, tokens.RefreshToken);

				await Clients.All.SendAsync("Tokens" , newToken);
			}	
			catch { throw new Exception(); }
		}
	}
}
