using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CirqulorBeMongo.Models
{
    public class NameOfMaterial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }  
        public string? Name { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BaseOfMaterials { get; set; }

        public string? BaseOfMaterialsName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? SourceOfMaterials { get; set; }

        [BsonIgnore]
        public List<SourceOfMaterial>? SourceOfMaterialList { get; set; }





    }
}
