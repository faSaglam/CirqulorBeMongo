
using CirqulorBeMongo.Models;

using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CirqulorBeMongo.Services
{
    public class TypeOfMaterialService
    {
        private readonly IMongoCollection<TypeOfMaterial> _types;
        public TypeOfMaterialService(IOptions<CirqulorDatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _types = mongoDatabase.GetCollection<TypeOfMaterial>(dbSettings.Value.TypeOfMaterialCollectionName);
        }
        public async Task<List<TypeOfMaterial>> GetAsync() => await _types.Find(_ => true).ToListAsync();
        public async Task<TypeOfMaterial?> GetByIdAsync(string id) => await _types.Find(x=>x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(TypeOfMaterial newType) => await _types.InsertOneAsync(newType);
        public async Task UpdateAsync(string id, TypeOfMaterial updatedType) => await _types.ReplaceOneAsync(x => x.Id == id, updatedType);
        public async Task RemoveAsync(string id) => await _types.DeleteOneAsync(x => x.Id == id);
    }
}
