using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClassLibraly.User
{
	public class EditUserModel
	{
		public string UserId { get; set; } = null!;
		public string? Login { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Description { get; set; }
		public List<string>? UserFriends { get; set; }
		public List<string>? UserGroups { get; set; }
		public List<string>? UserChats { get; set; }
	}
}
