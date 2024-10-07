using MessengerClassLibraly.User;
using MessengerHttpServiceLibraly.HttpServices.UserService.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WenawoMessenger.Server.UserInterface.Contollers
{
	[ApiController]
	[Route("/authorization/")]
	public class AuthorizationController(IAuthorizationService authorizationService) : Controller
	{
		private readonly IAuthorizationService _authorizationService = authorizationService;

		[HttpGet("login")]
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

		[HttpPost("registration")]
		public async Task<IActionResult> RegistrationAsync([FromBody] string email,
			[FromBody] string login, [FromBody] string password, [FromBody] DateTime dateOfBirth)
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
