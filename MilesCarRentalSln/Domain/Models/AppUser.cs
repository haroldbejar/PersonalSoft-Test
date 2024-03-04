using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Models
{
    public class AppUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("passwordhash")]
        public byte[] PasswordHash { get; set; }

        [BsonElement("passwordsalt")]
        public byte[] PasswordSalt { get; set; }
    }
}
