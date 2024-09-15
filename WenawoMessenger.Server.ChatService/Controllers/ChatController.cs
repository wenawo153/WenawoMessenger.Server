using MessengerClassLibraly.Chat;
using Microsoft.AspNetCore.Mvc;
using WenawoMessenger.Server.ChatService.Services.ChatService;
using ZstdSharp;

namespace WenawoMessenger.Server.ChatService.Controllers
{
	[ApiController]
	[Route("/[controller]")]
	public class ChatController(IChatService chatService) : Controller
	{
		private readonly IChatService _chatService = chatService;

		[HttpGet("GetChats")]
		public async Task<IActionResult> GetChats([FromQuery] List<int> chatsId)
		{
			try
			{
				var chats = await _chatService.GetChatsAsync(chatsId);

				if (chats.Count == 0) return NotFound("Chats not found");

				return Ok(chats);
			}
			catch (Exception) { throw new Exception("Get chats error"); };
		}

		[HttpPost("CreateChat")]
		public async Task<IActionResult> CreateChat([FromBody] ChatCreateData chatCreateData)
		{
			try
			{
				var newChat = await _chatService.CreateChatAsync(chatCreateData);

				if (newChat == null) return NotFound("Couldn't get information about the new chat");

				return Ok(newChat);
			}
			catch (Exception) { throw new Exception("Create chat error"); };
		 }

		[HttpPut("EditChat")]
		public async Task<IActionResult> EditChat([FromQuery] ChatEditData chatEditData)
		{
			try
			{
				var editChat = await _chatService.EditChatAsync(chatEditData);

				if (editChat == null) return NotFound("Couldn't get information about the edit chat");

				return Ok(editChat);
			}
			catch (Exception) { throw new Exception("Edit chat error"); };
		}

		[HttpDelete("DeleteChat")]
		public async Task<IActionResult> DeleteChat(int chatId)
		{
			try
			{
				await _chatService.DeleteChatAsycn(chatId);
				return Ok("Delete chat succsesful");
			}
			catch (Exception) { throw new Exception("Delete chat error"); };
		}
	}
}
