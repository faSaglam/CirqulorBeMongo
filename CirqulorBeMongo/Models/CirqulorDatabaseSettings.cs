using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirqulorBeMongo.Models
{
    public class CirqulorDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string BioBasedMaterialCollectionName { get; set; } = null!;

        public string TypeOfMaterialCollectionName { get; set; } = null!; 
        public string BaseOfMaterialCollectionName { get; set; } = null!;   
        public string NameOfMaterialCollectionName { get; set;} = null!;
        public string SourceOfMaterialCollectionName { get;set; } = null!;
        public string ProductionCollectionName { get; set; } = null!;
        public string ApplicationCollectionName { get; set; } = null!;
        public string UserCollectionName { get; set; } = null!; 
    }
}
