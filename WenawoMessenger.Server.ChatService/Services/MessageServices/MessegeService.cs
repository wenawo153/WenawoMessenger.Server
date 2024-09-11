using MessengerClassLibraly.Chat;
using MessengerClassLibraly.Messege;

namespace WenawoMessenger.Server.ChatService.Services.MessageServices
{
	public class MessegeService : IMessegeService
	{
		public async Task SendMessegeAsync(MessegeSendData messegeSendData)
		{
			throw new NotImplementedException();
		}

		public async Task<List<MessegeFullData>> GetMessegesInRangeAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<MessegeFullData> EditMessegeAsync(string newContent)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteMessegeAsync(long messegeId)
		{
			throw new NotImplementedException();
		}
	}
}
