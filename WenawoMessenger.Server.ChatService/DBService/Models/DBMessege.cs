using MessengerClassLibraly.Messege;
using System.ComponentModel.DataAnnotations.Schema;

namespace WenawoMessenger.Server.ChatService.DBService.Models
{
	public class DBMessege
	{
		public long Id { get; set; }
		public string SenderId { get; set; } = null!;
		public int ChatId { get; set; }
		public string Content { get; set; } = null!;
		[Column(TypeName = "timestamp(6)")]
		public DateTime SendedDateTime { get; set; }

		public MessegeFullData ConvertToMessegeFullData()
		{
			return new MessegeFullData
			{
				ChatId = ChatId,
				Content = Content,
				Id = Id,
				SendedDateTime = SendedDateTime,
				SenderId = SenderId
			};
		}
	}
}
