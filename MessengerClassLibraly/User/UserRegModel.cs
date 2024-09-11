using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClassLibraly.User
{
	public class UserRegModel
	{
		public string Email { get; set; } = null!;
		public string Login { get; set; } = null!;
		public string Password { get; set; } = null!;
		public DateTime DateOfBirth { get; set; }
	}
}
