using MessengerClassLibraly.Chat;
using MessengerClassLibraly.Messege;
using Microsoft.EntityFrameworkCore;
using WenawoMessenger.Server.ChatService.DBService;
using WenawoMessenger.Server.ChatService.DBService.Models;

namespace WenawoMessenger.Server.ChatService.Services.MessageServices
{
	public class MessegeService(ApplicationDBContext applicationDBContext) : IMessegeService
	{
		private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

		public async Task<MessegeFullData> CreateMessegeAsync(MessegeSendData messegeSendData)
		{
			try
			{
				var newMessege = new DBMessege()
				{
					ChatId = messegeSendData.ChatId,
					Content = messegeSendData.Content,
					SenderId = messegeSendData.SenderId,
					SendedDateTime = DateTime.Now,
				};

				await _applicationDBContext.Messeges.AddAsync(newMessege);
				await _applicationDBContext.SaveChangesAsync();

				return newMessege.ConvertToMessegeFullData();
			}
			catch (Exception) { throw new Exception("Create messege error)"); };

		}

		public async Task<List<MessegeFullData>> GetMessegesInRangeAsync(GetMessegeRequest getMessegeRequest)
		{
			try
			{
				var lastSearchingMessegeId = getMessegeRequest.FirstSearchMessegeId - getMessegeRequest.GetRange;
				var messeges = await _applicationDBContext.Messeges.Where(e =>
					(e.ChatId == getMessegeRequest.ChatId
					&& e.Id <= getMessegeRequest.FirstSearchMessegeId
					&& e.Id > lastSearchingMessegeId))
					.OrderBy(e => e.Id)
					.Select(e => e.ConvertToMessegeFullData())
					.ToListAsync();

				return messeges;
			}
			catch (Exception) { throw new Exception("Get messeges exeption"); };
		}

		public async Task<MessegeFullData> EditMessegeAsync(MessegeEditData messegeEditData)
		{
			try
			{
				var editableMessege = await _applicationDBContext.Messeges
					.FirstAsync(e => e.Id == messegeEditData.Id);

				var editMessege = new DBMessege()
				{
					Id = editableMessege.Id,
					ChatId = editableMessege.ChatId,
					Content = messegeEditData.Content,
					SendedDateTime = editableMessege.SendedDateTime,
					SenderId = editableMessege.SenderId,
				};

				_applicationDBContext.Messeges.Remove(editableMessege);
				await _applicationDBContext.AddAsync(editMessege);
				await _applicationDBContext.SaveChangesAsync();

				return editMessege.ConvertToMessegeFullData();
			}
			catch (Exception) { throw new Exception("Edit messege exeption"); };
		}

		public async Task DeleteMessegeAsync(long messegeId)
		{
			try
			{
				var deletebleMessege = await _applicationDBContext.Messeges.FirstAsync(e => e.Id == messegeId);

				if (deletebleMessege == null) throw new Exception("Messege not found");
				else _applicationDBContext.Messeges.Remove(deletebleMessege);
				await _applicationDBContext.SaveChangesAsync();
			}
			catch (Exception) { throw new Exception("Delete messege error"); };
		}

		public async Task DeleteMessegesAsync(List<long> messegeIds)
		{
			try
			{
				await _applicationDBContext.Messeges
					.Where(e => messegeIds.Contains(e.Id))
					.ExecuteDeleteAsync();
				await _applicationDBContext.SaveChangesAsync();
			}
			catch (Exception) { throw new Exception("Deleted messeges exeption"); };
		}

		public async Task DeleteAllChatMessegesAsync(int chatId)
		{
			try
			{
				await _applicationDBContext.Messeges
					.Where(e => e.ChatId == chatId)
					.ExecuteDeleteAsync();
				await _applicationDBContext.SaveChangesAsync();
			}
			catch (Exception) { throw new Exception("Deleted messeges exeption"); };
		}
	}
}
