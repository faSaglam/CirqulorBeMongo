using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CirqulorBeMongo.Models
{
    public class BaseOfMaterial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public string? Id { get; set; }
        public string? Name { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? TypeOfMaterials { get; set; }

        public string? TypeOfMaterialsName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? NameOfMaterials { get; set; }

        [BsonIgnore]
        public List<NameOfMaterial>? NameOfMaterialList { get; set; }



    }
}
