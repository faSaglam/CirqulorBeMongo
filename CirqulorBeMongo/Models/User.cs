using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CirqulorBeMongo.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Company { get; set; }
        public string? WebSite { get; set; }
        public string? JobTittle { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? SourceOfMaterials { get; set; }

        [BsonIgnore]
        public List<SourceOfMaterial>? SourceOfMaterialList { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? NameOfMaterials { get; set; }

        [BsonIgnore]
        public List<NameOfMaterial>? NameOfMaterialList { get; set; }


    }
}
