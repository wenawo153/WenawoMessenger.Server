﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClassLibraly.User
{
	public class UserStatus
	{
		public string UserId { get; set; } = null!;
		public enum UserState
		{
			Offline,
			Online
		}
	}
}
