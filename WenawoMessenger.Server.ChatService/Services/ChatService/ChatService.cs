using MessengerClassLibraly.Chat;
using WenawoMessenger.Server.ChatService.DBService;
using WenawoMessenger.Server.ChatService.DBService.Models;
using WenawoMessenger.Server.ChatService.Services.MessageServices;
using WenawoMessenger.Server.UserService.Models;

namespace WenawoMessenger.Server.ChatService.Services.ChatService
{
	public class ChatService(ApplicationDBContext applicationDBContext, IMessegeService messegeService) : IChatService
	{
		private readonly IMessegeService _messegeService = messegeService;
		private readonly ApplicationDBContext  _applicationDBContext = applicationDBContext;

		public async Task<ChatFullData> CreateChatAsync(ChatCreateData chatCreateData)
		{
			try
			{
				ChatFullData newChat = new()
				{
					HostId = chatCreateData.HostId,
					ChatCreatedDateTime = DateTime.Now,
					UsersId = chatCreateData.UsersId,
				};

				await _applicationDBContext.Chats.AddAsync(DBChat.ConvertOnChatFullData(newChat));
				await _applicationDBContext.SaveChangesAsync();

				return newChat;
			}
			catch (Exception) { throw new Exception("Create chat exeption"); };
		}

		public async Task<List<ChatFullData>> GetChatsAsync(List<int> ChatsId)
		{
			try
			{
				List<DBChat> dBChats = _applicationDBContext.Chats
					.Where(e => ChatsId.Contains(e.Id)).ToList();
				List<ChatFullData> chatsFullData = dBChats.Select(_ => _.ConvertInChatFullData()).ToList();

				return chatsFullData;
			}
			catch { throw new Exception("Exeption geting chats"); };
		}

		public async Task<ChatFullData> EditChatAsync(ChatEditData chatEditData)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteChatAsycn(int chatId)
		{
			throw new NotImplementedException();
		}
	}
}
