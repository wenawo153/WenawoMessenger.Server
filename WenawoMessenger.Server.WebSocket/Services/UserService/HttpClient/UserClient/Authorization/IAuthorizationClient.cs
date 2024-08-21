using WenawoMessenger.Server.WebSocket.Models;

namespace WenawoMessenger.Server.WebSocket.Services.UserService.HttpClient.UserClient.Authorization
{
    public interface IAuthorizationClient
    {
        public Task<User> Login(string name, string password);
        public Task<User> Registration(string name, string password);
    }
}
