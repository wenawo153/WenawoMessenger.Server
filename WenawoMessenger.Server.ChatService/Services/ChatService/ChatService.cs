using MessengerClassLibraly.Chat;
using Microsoft.EntityFrameworkCore;
using WenawoMessenger.Server.ChatService.DBService;
using WenawoMessenger.Server.ChatService.DBService.Models;
using WenawoMessenger.Server.ChatService.Services.MessageServices;

namespace WenawoMessenger.Server.ChatService.Services.ChatService
{
	public class ChatService(ApplicationDBContext applicationDBContext, IMessegeService messegeService) : IChatService
	{
		private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;
		private readonly IMessegeService _messegeService = messegeService;
		public async Task<ChatFullData> CreateChatAsync(ChatCreateData chatCreateData)
		{
			try
			{
				ChatFullData newChat = new()
				{
					HostId = chatCreateData.HostId,
					ChatCreatedDateTime = DateTime.Now,
					UsersId = chatCreateData.UsersId,
					ChatName = chatCreateData.ChatName
				};

				var bdChat = DBChat.ConvertOnChatFullData(newChat);

				await _applicationDBContext.Chats.AddAsync(bdChat);
				await _applicationDBContext.SaveChangesAsync();

				return bdChat.ConvertInChatFullData();
			}
			catch (Exception) { throw new Exception("Create chat error"); };
		}

		public async Task<List<ChatFullData>> GetChatsAsync(List<int> ChatsId)
		{
			try
			{
				var chats = await _applicationDBContext.Chats
					.Where(e => ChatsId.Contains(e.Id))
					.Select(e => e.ConvertInChatFullData())
					.ToListAsync();

				return chats;
			}
			catch { throw new Exception("Exeption geting chats"); };
		}

		public async Task<ChatFullData> EditChatAsync(ChatEditData chatEditData)
		{
			try
			{
				var editabledChat = await _applicationDBContext.Chats.FirstAsync(e => e.Id == chatEditData.Id);

				if (editabledChat == null) throw new Exception("Chat not found");

				var editChat = new DBChat()
				{
					Id = editabledChat!.Id,
					ChatCreatedDateTime = editabledChat!.ChatCreatedDateTime,
					HostId = chatEditData.HostId,
					UsersId = chatEditData.UsersId,
					ChatName = chatEditData.ChatName
				};

				_applicationDBContext.Chats.Remove(editabledChat);
				await _applicationDBContext.Chats.AddAsync(editChat);
				await _applicationDBContext.SaveChangesAsync();

				return editChat.ConvertInChatFullData();
			}
			catch (Exception) { throw new Exception("Edit chat error"); };
		}

		public async Task DeleteChatAsycn(int chatId)
		{
			try
			{
				var deletedChat = await _applicationDBContext.Chats.
					FirstAsync(e => e.Id == chatId);
				_applicationDBContext.Chats.Remove(deletedChat);
				await _applicationDBContext.SaveChangesAsync();
				await _messegeService.DeleteAllChatMessegesAsync(deletedChat.Id);
			}
			catch (Exception) { throw new Exception("Delete error (maybe chat not found)"); };
		}
	}
}
