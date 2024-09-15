using MessengerClassLibraly.Chat;

namespace MessengerHttpServiceLibraly.HttpServices.ChatService
{
	public interface IChatService
	{
		Task<ChatFullData> CreateChatAsync(ChatCreateData chatCreateData);
		Task DeleteChatAsync(int chatId);
		Task<ChatFullData> EditChatAsync(ChatEditData chatEditData);
		Task<List<ChatFullData>> GetChatsAsync(List<int> chatsId);
	}
}