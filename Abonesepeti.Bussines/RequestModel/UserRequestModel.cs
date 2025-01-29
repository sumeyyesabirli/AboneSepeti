using Abonesepeti.Core.Enum;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Abonesepeti.Bussines.RequestModel
{
    public class UserRequestModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("PasswordHash")]
        public string PasswordHash { get; set; }

        [BsonElement("UserType")]
        public UserType UserType { get; set; }

        [BsonElement("RefreshToken")]
        public string RefreshToken { get; set; }

        [BsonElement("RefreshTokenExpiryTime")]
        public DateTime? RefreshTokenExpiryTime { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}