using Flurl;
using Flurl.Http;
using WenawoMessenger.Server.WebSocket.Models;

namespace WenawoMessenger.Server.WebSocket.Services.UserService.HttpClient.UserClient.Authorization
{
    public class AuthorizationClient : IAuthorizationClient
    {
        private readonly string link = HttpConfig.userApiLink;

        public async Task<User> Login(string name, string password)
        {
            var url = new Url($"{link}/Authorization/Login")
                .SetQueryParams(new[] { ("name", name), ("password", password) });
            var result = await url.PostAsync() as User ?? new User();
            return result;
        }

        public async Task<User> Registration(string name, string password)
        {
            var url = new Url($"{link}/Authorization/Registration")
                .SetQueryParams(new[] { ("name", name), ("password", password) });
            var result = await url.PostAsync() as User ?? new User();
            return result;
        }
    }
}
