using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CirqulorBeMongo.Models
{
    public class TypeOfMaterial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? BioBasedMaterials { get; set; }

        public string? BioBasedMaterialName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ?BaseOfMaterials { get; set; }

        [BsonIgnore]
        public List<BaseOfMaterial>? BaseOfMaterialList { get; set; }




    }
}
