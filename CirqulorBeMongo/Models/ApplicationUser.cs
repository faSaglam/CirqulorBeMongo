

using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace CirqulorBeMongo.Models
{
    [CollectionName("Users")]
    public class ApplicationUser:MongoIdentityUser<Guid>
    {
        public string Company { get;set; }
        public string WebSite { get; set; }
        public string JobTittle {get;set; }
        public string PhotoUrl { get; set; }  
        public string Country { get; set; }
        public string Address { get; set; }

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
