using MessengerClassLibraly.User;
using MongoDB.Bson;
using WenawoMessenger.Server.UserService.Services.AuthorizationService;

namespace WenawoMessenger.Server.UserService.DBService.Models
{
	public class DBUser : UserFullData
	{
		public ObjectId Id { get; set; }

		public UserFullDataAndId ConvertToUserFullDataAndId()
		{
			return new()
			{
				UserId = Id.ToString(),
				Phone = Phone,
				DateOfBirth = DateOfBirth,
				DateOfRegistration = DateOfRegistration,
				Description = Description,
				Email = Email,
				LastOnline = LastOnline,
				Login = Login,
				Password = Password,
				UserChats = UserChats,
				UserFriends = UserFriends,
				UserGroups = UserGroups,
			};
		}

		public UserFullData ConvertToFullUserData()
		{
			return new()
			{
				Phone = Phone,
				DateOfBirth = DateOfBirth,
				DateOfRegistration = DateOfRegistration,
				Description = Description,
				Email = Email,
				LastOnline = LastOnline,
				Login = Login,
				Password = Password,
				UserChats = UserChats,
				UserFriends = UserFriends,
				UserGroups = UserGroups,
			};
		}

		public DBUser ConvertToUserDB(UserFullData userFullData)
		{
			return new()
			{
				Phone = userFullData.Phone,
				DateOfBirth = userFullData.DateOfBirth,
				DateOfRegistration = userFullData.DateOfRegistration,
				Description = userFullData.Description,
				Email = userFullData.Email,
				LastOnline = userFullData.LastOnline,
				Login = userFullData.Login,
				Password = userFullData.Password,
				UserChats = userFullData.UserChats,
				UserFriends = userFullData.UserFriends,
				UserGroups = userFullData.UserGroups,
			};
		}

		public DBUser ConvertToUserDBOnId(UserFullDataAndId userFullDataAndId)
		{
			return new()
			{
				Id = ObjectId.Parse(userFullDataAndId.UserId),
				Phone = userFullDataAndId.Phone,
				DateOfBirth = userFullDataAndId.DateOfBirth,
				DateOfRegistration = userFullDataAndId.DateOfRegistration,
				Description = userFullDataAndId.Description,
				Email = userFullDataAndId.Email,
				LastOnline = userFullDataAndId.LastOnline,
				Login = userFullDataAndId.Login,
				Password = userFullDataAndId.Password,
				UserChats = userFullDataAndId.UserChats,
				UserFriends = userFullDataAndId.UserFriends,
				UserGroups = userFullDataAndId.UserGroups,
			};
		}

		public UserViewData ConvertToUserViewData()
		{
			return new()
			{
				Description = Description,
				DateOfBirth = DateOfBirth,
				LastOnline = LastOnline,
				Login = Login,
				Phone = Phone,
				UserFriends = UserFriends,
				UserGroups = UserGroups
			};
		}

		public PersonUserGetData ConvertToPersonUserGetData()
		{
			return new()
			{
				Email = Email,
				UserGroups = UserGroups,
				UserFriends = UserFriends,
				Phone = Phone,
				Login = Login,
				LastOnline = LastOnline,
				DateOfBirth = DateOfBirth,
				DateOfRegistration = DateOfRegistration,
				Description = Description,
				UserChats = UserChats,
			};
		}
	}
}
