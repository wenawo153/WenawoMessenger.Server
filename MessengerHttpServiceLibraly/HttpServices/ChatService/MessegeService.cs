using Flurl;
using Flurl.Http;
using MessengerClassLibraly.Messege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerHttpServiceLibraly.HttpServices.ChatService
{
	public class MessegeService(HttpConfig httpConfig) : IMessegeService
	{
		private readonly string link = httpConfig.ChatLink;

		public async Task<List<MessegeFullData>> GetMessegesInRangeAsync(GetMessegeRequest getMessegeRequest)
		{
			try
			{
				var url = new Url($"{link}/Messege/GetMessegeInRange")
					.SetQueryParams(new[] { ("ChatId", getMessegeRequest.ChatId),
						("FirstSearchMessegeId", getMessegeRequest.FirstSearchMessegeId),
					("GetRange", getMessegeRequest.GetRange)});

				var responce = await url.GetJsonAsync<List<MessegeFullData>>();

				return responce;
			}
			catch (Exception) { throw new Exception("Get messege error"); };
		}

		public async Task<MessegeFullData> CreateMessegeAsync(MessegeSendData messegeSendData)
		{
			try
			{
				var url = new Url($"{link}/Messege/CreateMessege");

				var responce = await url.PostJsonAsync(messegeSendData).ReceiveJson<MessegeFullData>();

				return responce;
			}
			catch (Exception) { throw new Exception("Create messege error"); }
		}

		public async Task<MessegeFullData> EditMessegeAsync(MessegeEditData messegeEditData)
		{
			try
			{
				var url = new Url($"{link}/Messege/EditMessege");

				var responce = await url.PutJsonAsync(messegeEditData).ReceiveJson<MessegeFullData>();

				return responce;
			}
			catch (Exception) { throw new Exception("Edit messege error"); }
		}

		public async Task DeleteMessegeAsync(long messegeId)
		{
			try
			{
				var url = new Url($"{link}/Messege/DeleteMessege").SetQueryParam("messegeId", messegeId);

				var responce = await url.DeleteAsync();
			}
			catch (Exception) { throw new Exception("Delete messege error"); }
		}

		public async Task DeleteMessegesAsync(List<long> messegesId)
		{
			try
			{
				Dictionary<string, long> ids = messegesId
					.Select(e => ("messegesId", e))
					.ToDictionary();
				var url = new Url($"{link}/Messege/DeleteMesseges").SetQueryParams(ids);

				var responce = await url.DeleteAsync();
			}
			catch (Exception) { throw new Exception("Delete messeges error"); }
		}

		public async Task DeleteAllChatMessegesAsync(int chatId)
		{
			try
			{
				var url = new Url($"{link}/Messege/DeleteAllChatMesseges").SetQueryParam("chatId", chatId);

				var responce = await url.DeleteAsync();
			}
			catch (Exception) { throw new Exception("Delete messeges error"); }
		}

	}
}
