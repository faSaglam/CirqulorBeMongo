using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using CirqulorBeMongo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameOfMaterialController : ControllerBase
    {
        private readonly NameOfMaterialService _service;
        private readonly SourceOfMaterialService _somService;
        private readonly BaseOfMaterialService _baseOfMaterialService;
        private readonly TypeOfMaterialService _typeOfMaterialService;
        private readonly BioBasedMaterialService _bioBasedMaterialService;
        public NameOfMaterialController(
            NameOfMaterialService service, 
            SourceOfMaterialService somService,
            BaseOfMaterialService baseOfMaterialService,
            TypeOfMaterialService typeOfMaterialService,
            BioBasedMaterialService bioBasedMaterialService)
        {
            _service = service;
            _somService = somService;
            _baseOfMaterialService = baseOfMaterialService;
            _typeOfMaterialService = typeOfMaterialService;
            _bioBasedMaterialService = bioBasedMaterialService;
        }
        [HttpGet]
        public async Task<ActionResult<List<NameOfMaterial>>> GetAsync()
        {
           var nomList = await _service.GetAsyc();
           foreach(var item in nomList)
            {

              
                var nom = await _service.GetAsyncById(item.Id);
             
                var baseId = nom.BaseOfMaterials;
             
                var bom = await _baseOfMaterialService.GetByIdAsync(baseId);
             
                var bomName = bom.Name;
                item.BaseOfMaterialsName = bomName;
                
                var typeId = bom.TypeOfMaterials;
                var type = await _typeOfMaterialService.GetByIdAsync(typeId);
                item.TypeOfMaterialsName = type.Name;
                item.TypeOfMaterials = type.Id;
                var bioBaseId = type.BioBasedMaterials;
                var bioBase = await _bioBasedMaterialService.GetByIdAsync(bioBaseId);
                item.BioBasedMaterialsName = bioBase.Name;
                item.BioBasedMaterials = bioBase.Id;
                


            }
            return nomList;

        }
        [HttpGet("/type/{id}")]
        
        public async Task<List<NameOfMaterial>> GetAsyncByTypeId(string? id)
        {
            var nomlist = await _service.GetAsyc();
            var templist = new List<NameOfMaterial>();
            foreach (var item in nomlist)
            {
       
                var nom = await _service.GetAsyncById(item.Id);
                if (nom.TypeOfMaterials == id)
                {
                    templist.Add(nom);
                }

            }
            nomlist = templist;
            return nomlist;
        }


        [HttpGet]
        [Route("nonquery")]
        public async Task<List<NameOfMaterial>> GetAsyncWithBioBase()
        {
            var nomList = await _service.GetAsyc();
            return nomList;
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NameOfMaterial>> GetAsyncById(string id)
        {
            var nom = await _service.GetAsyncById(id);
            if(nom == null) 
            { 
                return NotFound(); 
            }
            var tempList = new List<SourceOfMaterial>();
            if(nom.SourceOfMaterials != null)
            {
                foreach (var sourceOfMaterialId in nom.SourceOfMaterials)
                {
                    if (sourceOfMaterialId != null)
                    {
                        var som = await _somService.GetAsyncById(sourceOfMaterialId);
                        tempList.Add(som);
                    }
                }
            }
        
            nom.SourceOfMaterialList = tempList;
            return nom;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var nom = await _service.GetAsyncById(id);
            if(nom != null)
            {
                return NotFound();
            }
          

            await _service.RemoveAsync(id);
            return NoContent();


        }
        [HttpPost]
        public async Task<ActionResult<NameOfMaterial>> PostAsync(NameOfMaterial nom)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest();
            }
            await _service.CreateAsync(nom);
            return Ok(nom);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<NameOfMaterial>> UpdateAsync(string id , NameOfMaterial nom)
        {
            var nomOrigin = await _service.GetAsyncById(id);
            if (nomOrigin == null)
            {
                return NotFound();
            }
            await _service.UpdateAsync(id, nom);
            return Ok(nom);
        }
   

    }
}
