using MessengerClassLibraly.Chat;
using MessengerHttpServiceLibraly.HttpServices.ChatService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WenawoMessenger.Server.UserInterface.Hubs.ChatsHub
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ChatsHub(IChatService chatService,
		IMessegeService messegeService) : Hub
	{
		private readonly IChatService _chatService = chatService;
		private readonly IMessegeService _messegeService = messegeService;

		public async Task InitializeChats(List<int> chatsId)
		{
			try
			{
				if (chatsId.Count == 0) throw new ArgumentException();

				var chats = await _chatService.GetChatsAsync(chatsId);

				await Clients.Caller.SendAsync("Chats", chats);
			}
			catch { throw new Exception(); }
		}

		public async Task CreateChat(ChatCreateData chatCreateData)
		{
			try
			{
				if (chatCreateData == null) throw new ArgumentNullException();

				var newChat = await _chatService.CreateChatAsync(chatCreateData);
			}
		}
	}
}
