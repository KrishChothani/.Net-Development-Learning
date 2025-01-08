using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Proj_2.Models
{
    public class User
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("userName"), BsonRepresentation(BsonType.String)]
        public string? UserName { get; set; }

        [BsonElement("emailId"), BsonRepresentation(BsonType.String)]
        public string? EmailId { get; set; }

        [BsonElement("password"), BsonRepresentation(BsonType.String)]
        public string? Password { get; set; }
    }
}
