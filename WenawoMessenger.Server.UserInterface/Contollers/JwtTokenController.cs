using MessengerClassLibraly.Tokens;
using MessengerHttpServiceLibraly.HttpServices.AuthenticationService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WenawoMessenger.Server.AuthenticationService.Models;
using WenawoMessenger.Server.UserInterface.Services.JwtService;

namespace WenawoMessenger.Server.UserInterface.Contollers
{
	[ApiController]
	[Route("/authentefication/")]
	public class JwtTokenController(IAuthenticationService authenticationService) : Controller
	{
		private IAuthenticationService _authenticationService = authenticationService;

		[HttpPost("refreshtoken")]
		public async Task<IActionResult> RefreshToken([FromBody] JwtTokens jwtTokens)
		{
			try
			{
				var claimService = new GetClaim();
				var userId = claimService.GetJWTTokenClaim(jwtTokens.AccessToken, "userId");

				UserJwtToken userJwtToken = await _authenticationService.RefreshTokenAsync(userId, jwtTokens.RefreshToken);
				JwtTokens tokens = new(userJwtToken);

				return Ok(tokens);
			}
			catch { throw new Exception(); }
		}
	}
}
