using WenawoMessenger.Server.UserService.DBService.Models;
using WenawoMessenger.Server.UserService.Models;

namespace WenawoMessenger.Server.UserService.Services.AuthorizationService
{
    public interface IAuthorizationService
    {
        public User Registration(string name, string password);
        public User Login(string name, string password);
    }
}
