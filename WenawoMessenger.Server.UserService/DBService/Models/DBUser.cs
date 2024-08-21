using MongoDB.Bson;
using WenawoMessenger.Server.UserService.Models;

namespace WenawoMessenger.Server.UserService.DBService.Models
{
    public class DBUser : User
    {
        public ObjectId Id { get; set; }
    }
}
