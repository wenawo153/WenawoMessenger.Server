using WenawoMessenger.Server.UserService.DBService;
using WenawoMessenger.Server.UserService.DBService.Models;
using WenawoMessenger.Server.UserService.Models;

namespace WenawoMessenger.Server.UserService.Services.AuthorizationService
{
    public class AuthorizationService(ApplicationDBContext applicationDBContext) : IAuthorizationService
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public User Login(string name, string password)
        {
            throw new NotImplementedException();
        }

        public User Registration(string name, string password)
        {
            DBUser user = new()
            {
                Name = name, 
                Password = password
            };

            _applicationDBContext.Add(user);
            _applicationDBContext.SaveChanges();

            return user;
        }
    }
}
