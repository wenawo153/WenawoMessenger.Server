using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WenawoMessenger.Server.AuthenticationService.Services.CreateTokenService;

namespace WenawoMessenger.Server.AuthenticationService.Controllers
{
	[ApiController]
	[Route("/authentication/[controller]")]
	public class CreateTokenController(ICreateTokenService createTokenService) : Controller
	{
		private readonly ICreateTokenService _createTokenService = createTokenService;

		[HttpGet]
		public async Task<IActionResult> CreateToken([Required] string userId)
		{
			try
			{
				var token = await _createTokenService.CreateTokenAsync(userId);
				return Ok(token);
			}
			catch (Exception) { throw new Exception(); }
		}
	}
}
