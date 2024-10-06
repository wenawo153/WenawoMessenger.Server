using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using WenawoMessenger.Server.AuthenticationService.DBService.Models;

namespace WenawoMessenger.Server.AuthenticationService.Models
{
    public class UserToken
    {
        public string UserId { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public RefreshToken RefreshToken { get; set; } = null!;

        public UserTokenDB ConvertToUserTokenDB()
        {
            return new()
            {
                AccessToken = AccessToken,
                RefreshToken = RefreshToken.Token,
                RefreshTokenCreated = RefreshToken.RefreshTokenCreated,
                RefreshTokenExpiration = RefreshToken.RefreshTokenExpiration,
                UserId = UserId
            };
        }
    }
}
