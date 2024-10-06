using Flurl.Util;
using MessengerClassLibraly.User;
using MessengerHttpServiceLibraly.HttpServices.AuthenticationService;
using MessengerHttpServiceLibraly.HttpServices.UserService.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;
using WenawoMessenger.Server.AuthenticationService.Models;

namespace WenawoMessenger.Server.UserInterface.Hubs.UserHub
{
	public class AuthHub(
		MessengerHttpServiceLibraly.HttpServices.UserService.Authorization.IAuthorizationService authorizationService,
		IAuthenticationService authenticationService) : Hub
	{

		private readonly IAuthenticationService _authenticationService = authenticationService;
		private readonly MessengerHttpServiceLibraly.HttpServices.UserService.Authorization.IAuthorizationService
			_authorizationService = authorizationService;

		public async Task Join(UserLogModel userLog)
		{
			var userLogResponce = await _authorizationService.LoginAsync(userLog)
				?? throw new Exception("Invalig login or password");

			await Clients.All.SendAsync("UserStatus", UserStatus.UserState.Online);
			await Clients.Caller.SendAsync("UserData", userLogResponce);
		}

		public async Task Registration(UserRegModel userReg)
		{
			var userLogResponce = await _authorizationService.RegistrationAsync(userReg)
				?? throw new Exception("Invalig request");

			await Clients.All.SendAsync("UserStatus", UserStatus.UserState.Online);
			await Clients.Caller.SendAsync("UserData", userLogResponce);
		}

		public async Task RefreshToken(UserJwtToken userJwt)
		{
			var uncodedToken = new JwtSecurityTokenHandler().ReadToken(userJwt.AccessToken);

			var now = DateTime.Now;

			if (uncodedToken.ValidTo > now)
			{
				await Task.Delay((int)(uncodedToken.ValidTo - now).TotalMilliseconds);
			}

			var newToken = await _authenticationService.RefreshTokenAsync(userJwt.UserId)
				?? throw new Exception("Refresh token no valid");

			await Clients.Caller.SendAsync("RefreshToken", newToken);
		}
	}
}
