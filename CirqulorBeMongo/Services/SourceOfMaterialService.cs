using CirqulorBeMongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CirqulorBeMongo.Services
{
    public class SourceOfMaterialService
    {
        private readonly IMongoCollection<SourceOfMaterial> _somCollection;
        public SourceOfMaterialService(IOptions<CirqulorDatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _somCollection = mongoDatabase.GetCollection<SourceOfMaterial>(dbSettings.Value.SourceOfMaterialCollectionName);
        }
        public async Task<List<SourceOfMaterial>> GetAsync() => await _somCollection.Find(_=>true).ToListAsync();
        public async Task<SourceOfMaterial> GetAsyncById(string id) => await _somCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(SourceOfMaterial newSom) => await _somCollection.InsertOneAsync(newSom);
        public async Task RemoveAsync(string id)=>await _somCollection.DeleteOneAsync(x=>x.Id == id);
        public async Task UpdateAsync(string id , SourceOfMaterial updatedSom) => await _somCollection.ReplaceOneAsync(x=>x.Id ==id, updatedSom);   
    }
}
