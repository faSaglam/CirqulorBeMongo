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

        public async Task<List<MaterialsOfProducer>> GetAsyncListByNomId(string name , string producerName)
        {
            var filter1 = Builders<MaterialsOfProducer>.Filter.Eq(x => x.NameOfMaterialName, name);
            var filter2 = Builders<MaterialsOfProducer>.Filter.Eq(x=>x.ProducerName, producerName);
            var combineFilter = Builders<MaterialsOfProducer>.Filter.And(new[] { filter1, filter2 });
            var results = await _mopCollection.Find(combineFilter).ToListAsync();
            return results;
        }
    }
}
