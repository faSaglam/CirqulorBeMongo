using CirqulorBeMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics.SymbolStore;

namespace CirqulorBeMongo.Services
{
    public class NameOfMaterialService
    {
        private readonly IMongoCollection<NameOfMaterial> _nomCollection;
        public NameOfMaterialService(IOptions<CirqulorDatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _nomCollection = mongoDatabase.GetCollection<NameOfMaterial>(dbSettings.Value.NameOfMaterialCollectionName);
        }
        public async Task<List<NameOfMaterial>> GetAsyc() => await _nomCollection.Find(_=>true).ToListAsync();
        public async Task<NameOfMaterial?> GetAsyncById(string id) 
        {
            var nom =await _nomCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return nom;

        }
    
        public async Task CreateAsync(NameOfMaterial newNameOfMaterial) => await _nomCollection.InsertOneAsync(newNameOfMaterial);
        public async Task UpdateAsync(string id , NameOfMaterial updatedNameOfMaterial)=>await _nomCollection.ReplaceOneAsync(x=>x.Id == id ,updatedNameOfMaterial);
        public async Task RemoveAsync(string id)=>await _nomCollection.DeleteOneAsync(x=>x.Id == id);
     
    }
}
