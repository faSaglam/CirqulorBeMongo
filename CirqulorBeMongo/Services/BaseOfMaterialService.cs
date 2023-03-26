using CirqulorBeMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CirqulorBeMongo.Services
{
    public class BaseOfMaterialService
    {
        private readonly IMongoCollection<BaseOfMaterial> _bomCollection;
        public BaseOfMaterialService(IOptions<CirqulorDatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _bomCollection = mongoDatabase.GetCollection<BaseOfMaterial>(dbSettings.Value.BaseOfMaterialCollectionName);
        }
        public async Task<List<BaseOfMaterial>> GetAsync() => await _bomCollection.Find(_ => true).ToListAsync();
        public async Task<BaseOfMaterial?> GetByIdAsync(string id)
        {
            var bom = await _bomCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return bom;
        }
        public async Task CreateAsync(BaseOfMaterial newBom) => await _bomCollection.InsertOneAsync(newBom);
        public async Task UpdateAsync(string id, BaseOfMaterial updatedBom) => await _bomCollection.ReplaceOneAsync(x => x.Id == id, updatedBom);
        public async Task RemoveAsync(string id) => await _bomCollection.DeleteOneAsync(x => x.Id == id);
    }
}
