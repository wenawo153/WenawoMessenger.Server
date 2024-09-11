using MongoDB.Bson.Serialization.Attributes;

namespace WenawoMessenger.Server.UserService.Models
{
	public class UserFullData
	{
		public string Email { get; set; } = null!;
		public string Login { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string Phone { get; set; } = "No number";
		public DateTime DateOfBirth { get; set; }
		public string Description { get; set; } = "No descriotion";
		public DateTime DateOfRegistration { get; set; }
		public DateTime LastOnline { get; set; }
		public List<string> UserFriends { get; set; } = [];
		public List<string> UserGroups { get; set; } = [];
		public List<string> UserChats { get; set; } = [];
	}
}
