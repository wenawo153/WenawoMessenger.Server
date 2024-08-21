﻿using Microsoft.AspNetCore.SignalR;
using WenawoMessenger.Server.WebSocket.Services.UserService.HttpClient.User.Authorization;

namespace WenawoMessenger.Server.WebSocket.Hubs.UserHub
{
    public class UserHub(IAuthorizationClient authorizationClient) : Hub
    {
        private readonly IAuthorizationClient _authorizationClient = authorizationClient;

        
    }
}
