using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CirqulorBeMongo.Models
{
   
    public class MaterialsOfProducer 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public object? Properties { get; set; }
        public string? Notes { get; set; }

       // name of material
        [BsonRepresentation(BsonType.ObjectId)]
        public string? NameOfMaterial { get; set; }

        public string? NameOfMaterialName { get; set; }

       // user
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Producer { get; set; }

        public string? ProducerName { get; set; }


    }
}
