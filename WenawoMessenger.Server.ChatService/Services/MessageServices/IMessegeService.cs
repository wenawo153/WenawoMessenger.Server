using MessengerClassLibraly.Messege;

namespace WenawoMessenger.Server.ChatService.Services.MessageServices
{
	public interface IMessegeService
	{
		public Task DeleteMessegeAsync(long messegeId);
		public Task<MessegeFullData> EditMessegeAsync(string newContent);
		public Task<List<MessegeFullData>> GetMessegesInRangeAsync();
		public Task SendMessegeAsync(MessegeSendData messegeSendData);
	}
}