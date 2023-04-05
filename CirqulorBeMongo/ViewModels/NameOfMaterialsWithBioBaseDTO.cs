using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CirqulorBeMongo.ViewModels
{
    public class NameOfMaterialsWithBioBaseDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
       
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BioBasedMaterials { get; set; }

        public string? BioBasedMaterialsName { get; set; }
    }
}
