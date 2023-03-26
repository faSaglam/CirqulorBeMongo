using CirqulorBeMongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CirqulorBeMongo.Services
{
    public class ApplicationService
    {
        private readonly IMongoCollection<Application> _aCollection;
        public ApplicationService(IOptions<CirqulorDatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _aCollection = mongoDatabase.GetCollection<Application>(dbSettings.Value.ApplicationCollectionName);
        }
        public async Task<List<Application>> GetAsync() => await _aCollection.Find(_ => true).ToListAsync();
        public async Task<ActionResult<Application>> GetAsyncById(string id) => await _aCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Application newApplication) => await _aCollection.InsertOneAsync(newApplication);
        public async Task RemoveAsync(string id) => await _aCollection.DeleteOneAsync(x => x.Id == id);
        public async Task UpdateAsync(string id, Application updatedApplication) => await _aCollection.ReplaceOneAsync(x => x.Id == id, updatedApplication);
    }
}
