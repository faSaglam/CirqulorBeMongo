using CirqulorBeMongo.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirqulorBeMongo.Models
{
    public class BioBasedMaterial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ?TypeOfMaterials { get; set; }

        [BsonIgnore]
        public List<TypeOfMaterial> ?TypeOfMaterialList { get; set; }

     
    }
}
