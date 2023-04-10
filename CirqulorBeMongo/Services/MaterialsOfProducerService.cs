using CirqulorBeMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CirqulorBeMongo.Services
{
    public class MaterialsOfProducerService
    {
        private readonly IMongoCollection<MaterialsOfProducer> _mopCollection;
        public MaterialsOfProducerService(IOptions<CirqulorDatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _mopCollection = mongoDatabase.GetCollection<MaterialsOfProducer>(dbSettings.Value.MaterialsOfProducerCollectionName);
        }
        public async Task<List<MaterialsOfProducer>> GetAsync() => await _mopCollection.Find(_ => true).ToListAsync();
        public async Task<MaterialsOfProducer?> GetByIdAsync(string id)
        {
            var materialsOfProducer = await _mopCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return materialsOfProducer;
        }
        public async Task CreateAsync(MaterialsOfProducer newMop) => await _mopCollection.InsertOneAsync(newMop);
        public async Task UpdateAsync(string id, MaterialsOfProducer updateMop) => await _mopCollection.ReplaceOneAsync(x => x.Id == id, updateMop);
        public async Task RemoveAsync(string id) => await _mopCollection.DeleteOneAsync(x => x.Id == id);
    }
}
