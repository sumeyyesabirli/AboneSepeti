using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Abonesepeti.Core.Entity
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; private set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; private set; }

        [BsonElement("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [BsonElement("IsDeleted")]
        public bool IsDeleted { get; set; }
       
    }
}
