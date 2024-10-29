using MessengerClassLibraly.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MongoDB.Bson;
using WenawoMessenger.Server.UserService.DBService;

namespace WenawoMessenger.Server.UserService.Services.UserDataService
{
	public class UserDataService(ApplicationDBContext applicationDBContext) : IUserDataService
	{
		private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

		public async Task<PersonUserGetData> GetPersonUserGetDataAsync(string userId)
		{
			try
			{
				if (!ObjectId.TryParse(userId, out var userObjId)) throw new ArgumentException();
				var userDB = await _applicationDBContext.Users.FirstAsync((_) => _.Id == userObjId);

				var user = userDB.ConvertToPersonUserGetData();
				return user;
			}
			catch { throw new Exception(); }
		}

		public async Task<UserViewData> GetUserViewDataAsync(string userId)
		{
			try
			{
				if (!ObjectId.TryParse(userId, out var userObjId)) throw new ArgumentException();
				var userDB = await _applicationDBContext.Users.FirstAsync((_) => _.Id == userObjId);

				var user = userDB.ConvertToUserViewData();
				return user;
			}
			catch { throw new Exception(); }
		}

		public async Task<PersonUserGetData> EditUserDataAsync(EditUserModel editUserModel)
		{
			try
			{
				if (!ObjectId.TryParse(editUserModel.UserId, out var userObjId)) throw new ArgumentException();
				var userDB = await _applicationDBContext.Users.FirstAsync((_) => _.Id == userObjId);

				if (editUserModel.Login != null) userDB.Login = editUserModel.Login;
				if (editUserModel.DateOfBirth != null) userDB.DateOfBirth = editUserModel.DateOfBirth.Value;
				if (editUserModel.Description != null) userDB.Description = editUserModel.Description;
				if (editUserModel.UserFriends != null) userDB.UserFriends = editUserModel.UserFriends;
				if (editUserModel.UserGroups != null) userDB.UserGroups = editUserModel.UserGroups;
				if (editUserModel.UserChats != null) userDB.UserChats = editUserModel.UserChats;
				await _applicationDBContext.SaveChangesAsync();

				var user = userDB.ConvertToPersonUserGetData();

				return user;
			}
			catch { throw new Exception(); }
		}
	}
}
