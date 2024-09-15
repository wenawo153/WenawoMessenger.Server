using MessengerClassLibraly.User;
using Microsoft.AspNetCore.Mvc;
using WenawoMessenger.Server.UserService.Services.AuthorizationService;

namespace WenawoMessenger.Server.UserService.Controllers
{
	[ApiController]
	[Route("/[controller]")]
	public class AuthorizationController(IAuthorizationService authorizationService) : Controller
	{
		private readonly IAuthorizationService _authorizationService = authorizationService;

		[HttpPost ("Registration")]
		public async Task<IActionResult> Registration([FromBody] UserRegModel userRegModel)
		{
			try
			{
				UserLogResponce userLogResponce = await _authorizationService.RegistrationAsync(userRegModel);
				return Ok(userLogResponce);
			}
			catch (Exception) { throw new Exception("Registration service error"); };

		}

		[HttpGet ("Login")]
		public async Task<IActionResult> Login([FromQuery] UserLogModel userLogModel)
		{
			try
			{
				UserLogResponce userLogResponce = await _authorizationService.LoginAsync(userLogModel);
				return Ok(userLogResponce);
			}
			catch (Exception) { throw new Exception("Login Service error"); };
		}
	}
}
