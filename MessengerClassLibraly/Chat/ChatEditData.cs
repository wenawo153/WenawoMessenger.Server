using MessengerClassLibraly.Messege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClassLibraly.Chat
{
	public class ChatEditData
	{
		public string HostId { get; set; } = null!;
		public List<string> UsersId { get; set; } = null!;
		public List<MessegeFullData>? Messeges { get; set; }
	}
}
