using MessengerClassLibraly.Messege;

namespace WenawoMessenger.Server.ChatService.Services.MessageServices
{
	public interface IMessegeService
	{
		public Task DeleteMessegeAsync(long messegeId);
		public Task<MessegeFullData> EditMessegeAsync(MessegeEditData messegeEditData);
		public Task<List<MessegeFullData>> GetMessegesInRangeAsync(GetMessegeRequest getMessegeRequest);
		public Task<MessegeFullData> CreateMessegeAsync(MessegeSendData messegeSendData);
		public Task DeleteMessegesAsync(List<long> messegeIds);
		public Task DeleteAllChatMessegesAsync(int chatId);
	}
}