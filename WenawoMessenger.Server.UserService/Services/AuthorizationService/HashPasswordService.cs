using WenawoMessenger.Server.UserService.DBService;

namespace WenawoMessenger.Server.UserService.Services.AuthorizationService
{
	public class HashPasswordService(ApplicationDBContext applicationDBContext)
	{
		private ApplicationDBContext _applicationDBContext = applicationDBContext;

		public string HashedPassword(string password)
		{
			return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
		}

		public bool VerifyPassword(string dbPassword, string logPassword)
		{
			bool verifyResult = BCrypt.Net.BCrypt.EnhancedVerify(logPassword, dbPassword);

			return verifyResult;
		}
	}
}
