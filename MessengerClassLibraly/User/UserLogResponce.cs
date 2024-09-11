using WenawoMessenger.Server.UserService.Models;

namespace MessengerClassLibraly.User
{
	public class UserLogResponce
	{
		public string UserId { get; set; } = null!;
		public string JwtToken { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Login { get; set; } = null!;
		public string Phone { get; set; } = "No number";
		public DateTime DateOfBirth { get; set; }
		public string Description { get; set; } = "No descriotion";
		public DateTime DateOfRegistration { get; set; }
		public DateTime LastOnline { get; set; }
		public List<string> UserFriends { get; set; } = [];
		public List<string> UserGroups { get; set; } = [];
		public List<string> UserChats { get; set; } = [];


		public static UserLogResponce ConvertUserLogResponce(string userId, string jwtToken, UserFullData userFullData)  
		{
			return new()
			{
				DateOfBirth = userFullData.DateOfBirth,
				DateOfRegistration = userFullData.DateOfRegistration,
				Description = userFullData.Description,
				Email = userFullData.Email,
				JwtToken = jwtToken,
				LastOnline = userFullData.LastOnline,
				Login = userFullData.Login,
				Phone = userFullData.Phone,
				UserChats = userFullData.UserChats,
				UserFriends = userFullData.UserFriends,
				UserGroups = userFullData.UserGroups,
				UserId = userId
			};
		}

		public static UserLogResponce ConvertUserLogResponce(string jwtToken, UserFullDataAndId userFullDataAndId)
		{
			return new()
			{
				UserId = userFullDataAndId.UserId,
				UserGroups = userFullDataAndId.UserGroups,
				UserFriends = userFullDataAndId.UserFriends,
				DateOfBirth = userFullDataAndId.DateOfBirth,
				JwtToken =jwtToken,
				DateOfRegistration = userFullDataAndId.DateOfRegistration,
				Description=userFullDataAndId.Description,
				Email = userFullDataAndId.Email,
				LastOnline= userFullDataAndId.LastOnline,
				Login = userFullDataAndId.Login,
				Phone= userFullDataAndId.Phone,
				UserChats = userFullDataAndId.UserChats
			};
		}
	}
}
