


using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace CirqulorBeMongo.Models
{
    [CollectionName("Roles")]
    public class ApplicationRole:MongoIdentityRole<Guid>
    {
        
    }
}
