using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenawoMessenger.Server.UserService.Models;

namespace MessengerClassLibraly.User
{
	public class UserFullDataAndId : UserFullData
	{
		public string UserId { get; set; } = null!;
	}
}
