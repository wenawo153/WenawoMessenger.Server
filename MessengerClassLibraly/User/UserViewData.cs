using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClassLibraly.User
{
    public class UserViewData
    {
		public string Login { get; set; } = null!;
		public string Phone { get; set; } = "No number";
		public DateTime DateOfBirth { get; set; }
		public string Description { get; set; } = "No descriotion";
		public DateTime LastOnline { get; set; }
		public List<string> UserFriends { get; set; } = [];
		public List<string> UserGroups { get; set; } = [];
	}
}
