using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenawoMessenger.Server.AuthenticationService.Models;

namespace MessengerClassLibraly.Tokens
{
    public class JwtTokens
    {
		public string AccessToken { get; set; } = null!;
		public string RefreshToken { get; set; } = null!;

		public JwtTokens() { }

		public JwtTokens(string accessToken, string refreshToken)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}

		public JwtTokens(UserJwtToken tokens)
		{
			AccessToken = tokens.AccessToken;
			RefreshToken = tokens.RefreshToken;
		}
	}
}
