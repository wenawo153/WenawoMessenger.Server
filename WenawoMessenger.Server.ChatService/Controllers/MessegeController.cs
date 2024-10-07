using MessengerClassLibraly.Messege;
using Microsoft.AspNetCore.Mvc;
using WenawoMessenger.Server.ChatService.Services.MessageServices;

namespace WenawoMessenger.Server.ChatService.Controllers
{
	[ApiController]
	[Route("/messege/")]
	public class MessegeController(IMessegeService messegeService) : Controller
	{
		private readonly IMessegeService _messegeService = messegeService;

		[HttpGet("getmessegeinrange")]
		public async Task<IActionResult> GetMessegeInRange([FromQuery] GetMessegeRequest getMessegeRequest)
		{
			try
			{
				var messeges = await _messegeService.GetMessegesInRangeAsync(getMessegeRequest);

				if (messeges.Count == 0) return NotFound("Messeges not found");

				return Ok(messeges);
			}
			catch (Exception) { throw new Exception("Get messege error"); };
		}

		[HttpPost("createmessege")]
		public async Task<IActionResult> CreateMessege([FromBody] MessegeSendData messegeSendData)
		{
			try
			{
				var newMessege = await _messegeService.CreateMessegeAsync(messegeSendData);

				if (newMessege == null) return NotFound("Couldn't get information about the new messege");

				return Ok(newMessege);
			}
			catch (Exception) { throw new Exception("Create messege error"); }
		}

		[HttpPut("editmessege")]
		public async Task<IActionResult> EditMessege([FromBody] MessegeEditData messegeEditData)
		{
			try
			{
				var editMessege = await _messegeService.EditMessegeAsync(messegeEditData);

				if (editMessege == null) return NotFound("Couldn't get information about the edit messege");

				return Ok(editMessege);
			}
			catch (Exception) { throw new Exception("Edit messege error"); }
		}

		[HttpDelete("deletemessege")]
		public async Task<IActionResult> DeleteMessege([FromQuery] long messegeId)
		{
			try
			{
				await _messegeService.DeleteMessegeAsync(messegeId);

				return Ok("Delete messege succsesful");
			}
			catch { throw new Exception("Delete messege error"); };
		}
		
		[HttpDelete("deletemesseges")]
		public async Task<IActionResult> DeleteMesseges([FromBody]List<long> messegeIds)
		{
			try
			{
				await _messegeService.DeleteMessegesAsync(messegeIds);

				return Ok("Delete messege succsesful");
			}
			catch { throw new Exception("Delete messeges error"); };
		}
		
		[HttpDelete("deleteallchatmesseges")]
		public async Task<IActionResult> DeleteAllChatMesseges([FromQuery]int chatId)
		{
			try
			{
				await _messegeService.DeleteAllChatMessegesAsync(chatId);

				return Ok("Delete messege succsesful");
			}
			catch { throw new Exception("Delete messeges error"); };
		}
	}
}
