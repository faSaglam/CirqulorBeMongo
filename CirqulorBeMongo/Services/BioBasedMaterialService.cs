using CirqulorBeMongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirqulorBeMongo.Services
{
    public class BioBasedMaterialService
    {
        private readonly IMongoCollection<BioBasedMaterial> _bbmCollection;
        public BioBasedMaterialService(IOptions<CirqulorDatabaseSettings> dbSettings) 
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _bbmCollection = mongoDatabase.GetCollection<BioBasedMaterial>(dbSettings.Value.BioBasedMaterialCollectionName);
        }
        public async Task<List<BioBasedMaterial>> GetAsync ()=> await _bbmCollection.Find(_=>true).ToListAsync();
        public async Task<BioBasedMaterial?> GetByIdAsync(string id) {
           var biobasedMaterial =  await _bbmCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
           
            return biobasedMaterial;
        }
        public async Task CreateAsync(BioBasedMaterial newbioBasedMaterial) => await _bbmCollection.InsertOneAsync(newbioBasedMaterial);
        public async Task UpdateAsync(string id, BioBasedMaterial updatebioBasedMaterial)=>await _bbmCollection.ReplaceOneAsync(x=>x.Id == id, updatebioBasedMaterial);
        public async Task RemoveAsync(string id)=> await _bbmCollection.DeleteOneAsync(x=>x.Id == id);
    }
}
