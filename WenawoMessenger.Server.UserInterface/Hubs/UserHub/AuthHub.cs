﻿using MessengerClassLibraly.User;
using MessengerHttpServiceLibraly.HttpServices.AuthenticationService;
using Microsoft.AspNetCore.SignalR;

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
	}
}
