namespace WenawoMessenger.Server.ChatService.DBService.Models
{
	public class DBMessege
	{
		public long Id { get; set; }
		public string SenderId { get; set; } = null!;
		public string ChatId { get; set; } = null!;
		public string Content { get; set; } = null!;
		public DateTime SendedDateTime { get; set; }
	}
}
