using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using WenawoMessenger.Server.AuthenticationService.Services.RefreshTokenService;

namespace WenawoMessenger.Server.AuthenticationService.Controllers
{
	[ApiController]
	[Route("/refreshtoken/[controller]")]
	public class RefreshTokenController(IRefreshTokenService refreshTokenService) : Controller
	{
		private readonly IRefreshTokenService _refreshTokenService = refreshTokenService;

		[HttpPost]
		public async Task<IActionResult> RefreshToken([Required] string userId, [Required] string refreshToken)
		{
			try
			{
				var token = await _refreshTokenService.RefreshTokenAsync(userId, refreshToken);
				return Ok(token);
			}
			catch (Exception) { throw new Exception(); };
		}
	}
}
