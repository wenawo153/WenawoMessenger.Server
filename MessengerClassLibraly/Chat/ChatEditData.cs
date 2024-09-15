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
		public int Id { get; set; }
		public string ChatName { get; set; } = null!;
		public string HostId { get; set; } = null!;
		public List<string> UsersId { get; set; } = null!;
	}
}
