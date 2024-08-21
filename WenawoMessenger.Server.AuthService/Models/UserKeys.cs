using MongoDB.Bson;

namespace WenawoMessenger.Server.AuthenticationService.Models
{
    public class UserKeys
    {
        public ObjectId UserId { get; set; }

        public string PublicKey { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
    }
}
