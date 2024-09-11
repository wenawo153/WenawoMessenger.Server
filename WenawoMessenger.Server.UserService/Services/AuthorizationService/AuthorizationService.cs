using MessengerClassLibraly.User;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;
using WenawoMessenger.Server.UserService.DBService;
using WenawoMessenger.Server.UserService.DBService.Models;
using WenawoMessenger.Server.UserService.HttpServices.Services.AuthService;

namespace WenawoMessenger.Server.UserService.Services.AuthorizationService
{
	public class AuthorizationService(ApplicationDBContext applicationDBContext, 
		HashPasswordService hashPasswordService, IAuthService authService) : IAuthorizationService
	{
		private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;
		private readonly HashPasswordService _hashPasswordService = hashPasswordService;
		private readonly IAuthService _authService = authService;

		public async Task<UserLogResponce> LoginAsync(UserLogModel userLogData)
		{
			try
			{
				var userDataDB = await _applicationDBContext.Users.FirstOrDefaultAsync(e => e.Email == userLogData.Email)
					?? throw new Exception("User not avalaible");

				if (_hashPasswordService.VerifyPassword(userDataDB.Password, userLogData.Password))
				{
					var userData = userDataDB.ConvertToUserFullDataAndId();
					var userToken = await _authService.CreateTokenAsync(userData.UserId);
					var userLogResponce = UserLogResponce.ConvertUserLogResponce(userToken, userData);

					return userLogResponce;
				}
				else throw new Exception("Password verify error");
			}
			catch (Exception) { throw new Exception("Login exception"); };
		}

		public async Task<UserLogResponce> RegistrationAsync(UserRegModel userRegData)
		{
			try
			{
				string hashedPassword = _hashPasswordService.HashedPassword(userRegData.Password);

				DBUser newUser = new()
				{
					DateOfBirth = userRegData.DateOfBirth.Date,
					DateOfRegistration = DateTime.Now,
					Email = userRegData.Email,
					Login = userRegData.Login,
					Password = hashedPassword,
				};

				await _applicationDBContext.Users.AddAsync(newUser);
				await _applicationDBContext.SaveChangesAsync();

				var userToken = await _authService.CreateTokenAsync(newUser.Id.ToString());

				return UserLogResponce.ConvertUserLogResponce(userToken, newUser.ConvertToUserFullDataAndId());
			}
			catch (Exception) { throw new Exception("Registration exeption"); };
		}
	}
}
