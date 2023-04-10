using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CirqulorBeMongo.Models
{
    public class SourceOfMaterial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? NameOfMaterials { get; set; }

        public string? NameOfMaterialName { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        //public List<string>? Users { get; set; }

        //[BsonIgnore]
        //public List<ApplicationUser>? UserList { get; set; }
    }
}
