using CirqulorBeMongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CirqulorBeMongo.Services
{
    public class ProductionService
    {
       
            private readonly IMongoCollection<Production> _pCollection;
            public ProductionService(IOptions<CirqulorDatabaseSettings> dbSettings)
            {
                var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
                var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
                _pCollection = mongoDatabase.GetCollection<Production>(dbSettings.Value.ProductionCollectionName);
            }
            public async Task<List<Production>> GetAsync() => await _pCollection.Find(_ => true).ToListAsync();
            public async Task<ActionResult<Production>> GetAsyncById(string id) => await _pCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            public async Task CreateAsync(Production newProduction) => await _pCollection.InsertOneAsync(newProduction);
            public async Task RemoveAsync(string id) => await _pCollection.DeleteOneAsync(x => x.Id == id);
            public async Task UpdateAsync(string id, Production updatedProduction) => await _pCollection.ReplaceOneAsync(x => x.Id == id, updatedProduction);
        
    }
}
