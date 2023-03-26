using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CirqulorBeMongo.Models
{
    public class Production
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
