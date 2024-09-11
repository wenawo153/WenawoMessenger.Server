using MessengerClassLibraly.Chat;

namespace WenawoMessenger.Server.ChatService.Services.ChatService
{
	public interface IChatService
	{
		public Task<ChatFullData> CreateChatAsync(ChatCreateData chatCreateData);
		public Task<ChatFullData> EditChatAsync(ChatEditData chatEditData);
		public Task<List<ChatFullData>> GetChatsAsync(List<int> chatsId);
		public Task DeleteChatAsycn(int chatId);
	}
}