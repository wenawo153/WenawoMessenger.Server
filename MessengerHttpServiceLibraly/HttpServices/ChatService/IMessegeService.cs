using MessengerClassLibraly.Messege;

namespace MessengerHttpServiceLibraly.HttpServices.ChatService
{
	public interface IMessegeService
	{
		Task<MessegeFullData> CreateMessegeAsync(MessegeSendData messegeSendData);
		Task DeleteAllChatMessegesAsync(int chatId);
		Task DeleteMessegeAsync(long messegeId);
		Task DeleteMessegesAsync(List<long> messegesId);
		Task<MessegeFullData> EditMessegeAsync(MessegeEditData messegeEditData);
		Task<List<MessegeFullData>> GetMessegesInRangeAsync(GetMessegeRequest getMessegeRequest);
	}
}