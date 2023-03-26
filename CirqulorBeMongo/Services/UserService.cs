using CirqulorBeMongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CirqulorBeMongo.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;
        public UserService(IOptions<CirqulorDatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<User>(dbSettings.Value.UserCollectionName);
        }
        public async Task<List<User>> GetAsync() => await _userCollection.Find(_ => true).ToListAsync();
        public async Task<ActionResult<User>> GetAsyncById(string id) => await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(User newUser) => await _userCollection.InsertOneAsync(newUser);
        public async Task RemoveAsync(string id) => await _userCollection.DeleteOneAsync(x => x.Id == id);
        public async Task UpdateAsync(string id, User updatedUser) => await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);
    }
}
