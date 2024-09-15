using Flurl;
using Flurl.Http;
using MessengerClassLibraly.Chat;

namespace MessengerHttpServiceLibraly.HttpServices.ChatService
{
	public class ChatService(HttpConfig httpConfig) : IChatService
	{
		private readonly string link = httpConfig.ChatLink;

		public async Task<ChatFullData> CreateChatAsync(ChatCreateData chatCreateData)
		{
			try
			{
				var url = new Url($"{link}/Chat/CreateChat");

				var responce = await url.PostJsonAsync(chatCreateData).ReceiveJson<ChatFullData>();

				return responce;
			}
			catch (Exception) { throw new Exception("Create chat error"); };
		}

		public async Task<ChatFullData> EditChatAsync(ChatEditData chatEditData)
		{
			try
			{
				var url = new Url($"{link}/Chat/EditChat");

				var responce = await url.PutJsonAsync(chatEditData).ReceiveJson<ChatFullData>();

				return responce;
			}
			catch (Exception) { throw new Exception("Edit chat error"); };
		}

		public async Task<List<ChatFullData>> GetChatsAsync(List<int> chatsId)
		{
			try
			{
				Dictionary<string, int> ids = chatsId
					.Select(e => ("chatId", e))
					.ToDictionary();

				var url = new Url($"{link}/Chat/GetChats").SetQueryParams(ids);

				var responce = await url.GetJsonAsync<List<ChatFullData>>();

				return responce;
			}
			catch (Exception) { throw new Exception("Get chat error"); };
		}

		public async Task DeleteChatAsync(int chatId)
		{
			try
			{
				var url = new Url($"{link}/Chat/CreateChat").SetQueryParam("chatId", chatId);

				var responce = await url.DeleteAsync();
			}
			catch (Exception) { throw new Exception("Delete chat error"); };
		}
	}
}
