using MessengerClassLibraly.User;
using Microsoft.AspNetCore.Mvc;
using WenawoMessenger.Server.UserService.Services.UserDataService;

namespace WenawoMessenger.Server.UserService.Controllers
{
	[ApiController]
	[Route("/data/")]
	public class UserDataController(IUserDataService userDataService) : Controller
	{
		private IUserDataService _userDataService = userDataService;

		[HttpGet("getpersondata")]
		public async Task<IActionResult> GetPersonUserData([FromQuery]string userId)
		{
			try
			{
				var user = await _userDataService.GetPersonUserGetDataAsync(userId);
				return Ok(user);
			}
			catch { throw new Exception(); }
		}

		[HttpGet("getviewuserdata")]
		public async Task<IActionResult> GetViewUserDataAsync([FromQuery] string userId)
		{
			try
			{
				var user = await _userDataService.GetUserViewDataAsync(userId);
				return Ok(user);
			}
			catch { throw new Exception(); }
		}

		[HttpPost("edituserdata")]
		public async Task<IActionResult> EditUserDataAsync(EditUserModel editUserModel)
		{
			try
			{
				var user = await _userDataService.EditUserDataAsync(editUserModel);
				return Ok(user);
			}
			catch { throw new Exception(); }
		}
	}
}
