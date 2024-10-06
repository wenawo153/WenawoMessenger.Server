using MessengerClassLibraly.User;
using MessengerHttpServiceLibraly.HttpServices.UserService.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WenawoMessenger.Server.UserInterface.Contollers
{
	[ApiController]
	[Route("/[controller]")]
	public class AuthorizationController(IAuthorizationService authorizationService) : Controller
	{
		private readonly IAuthorizationService _authorizationService = authorizationService;

		[HttpGet("Login")]
		public async Task<IActionResult> LoginAsync([FromQuery]string email,[FromQuery] string password)
		{
			try
			{
				UserLogModel logModel = new UserLogModel(email, password);

				UserLogResponce responce = await _authorizationService.LoginAsync(logModel);

				return Ok(responce);
			}
			catch (Exception) { throw new Exception(); };
		}

		[HttpGet("Registration")]
		public async Task<IActionResult> RegistrationAsync([FromQuery] string email,
			[FromQuery] string login, [FromQuery] string password, [FromQuery] DateTime dateOfBirth)
		{
			try
			{
				UserRegModel regModel = new UserRegModel(email, login, password, dateOfBirth);

				UserLogResponce responce = await _authorizationService.RegistrationAsync(regModel);

				return Ok(responce);
			}
			catch (Exception) { throw new Exception(); };
		}
	}
}
