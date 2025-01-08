using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_Id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UserName"), BsonRepresentation(BsonType.String)]
        public string? UserName { get; set; }

        [BsonElement("Email"), BsonRepresentation(BsonType.String)]
        public string? Email { get; set; }

        [BsonElement("Password"), BsonRepresentation(BsonType.String)]
        public string? Password { get; set; }
    }
}
