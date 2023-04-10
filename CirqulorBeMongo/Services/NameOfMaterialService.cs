using CirqulorBeMongo.Models;
using CirqulorBeMongo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Diagnostics.SymbolStore;
using System.Runtime;

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
        //public async Task<List<NameOfMaterial>> GetAsyncByTypeId(string Id)

        //{
         
        //    //var filter = Builders<NameOfMaterial>.Filter.Eq(x => x.TypeOfMaterials , Id);

        //    //var results = await _nomCollection.Find(filter).ToListAsync();
        //    //var results = await _nomCollection.AsQueryable().Where(x => x.TypeOfMaterials == objectId).ToListAsync();
        //    //return results;


        //    //var nomList = await _nomCollection.I
        //    //return nomList;
        //    //var filter = builder.ElemMatch(u => u.TypeOfMaterials, typeId);

        //    //var cursor = _nomCollection.Find(filter);
        //    //var nomList =await cursor.ToListAsync();

        //    //return nomList;
        //    ///
        //    //var nom = await _nomCollection.Find(x=>x.TypeOfMaterials == typeId).FirstOrDefaultAsync();
        //    //return nom;
        //}

        public async Task CreateAsync(NameOfMaterial newNameOfMaterial) => await _nomCollection.InsertOneAsync(newNameOfMaterial);
        public async Task UpdateAsync(string id , NameOfMaterial updatedNameOfMaterial)=>await _nomCollection.ReplaceOneAsync(x=>x.Id == id ,updatedNameOfMaterial);
        public async Task RemoveAsync(string id)=>await _nomCollection.DeleteOneAsync(x=>x.Id == id);
     
    }
}
