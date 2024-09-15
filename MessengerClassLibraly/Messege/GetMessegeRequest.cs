namespace MessengerClassLibraly.Messege
{
	public class GetMessegeRequest
	{
		public int ChatId { get; set; }
		public long FirstSearchMessegeId { get; set; } = 0;
		public int GetRange { get; set; } = 1;
	}
}
