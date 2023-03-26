using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfMaterialController : ControllerBase
    {
        private readonly TypeOfMaterialService _tomService;
        private readonly BioBasedMaterialService _bbmService;
        private readonly BaseOfMaterialService _bomService;
        public TypeOfMaterialController(TypeOfMaterialService tomService , BioBasedMaterialService bbmService , BaseOfMaterialService bomServie)
        {
            _tomService = tomService;
            _bbmService = bbmService;
            _bomService = bomServie;
        }
        [HttpGet]
        public async Task<List<TypeOfMaterial>> GetAsync()
        {
            var typeOfMaterialList = await _tomService.GetAsync();
            foreach(var typeOfMaterial in typeOfMaterialList)
            {
                var tom = await _tomService.GetByIdAsync(typeOfMaterial.Id);
                var bbmId = tom.BioBasedMaterials;
                var bbm = await _bbmService.GetByIdAsync(bbmId);
                if(bbm != null)
                {
                    typeOfMaterial.BioBasedMaterialName = bbm.Name;
                }
                

            }
            return typeOfMaterialList;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfMaterial>> GetById(string id)
        {
            var typeOfMaterial = await _tomService.GetByIdAsync(id);
            if(typeOfMaterial == null)
            {
                return NotFound();
            }
            
            string bbmId = typeOfMaterial.BioBasedMaterials;
            var bbm = await _bbmService.GetByIdAsync(bbmId);
            typeOfMaterial.BioBasedMaterialName = bbm.Name;

            var tempList = new List<BaseOfMaterial>();
            foreach(var baseOfMaterialId in typeOfMaterial.BaseOfMaterials)
            {
                if(baseOfMaterialId != null)
                {
                    var baseOfMaterial = await _bomService.GetByIdAsync(baseOfMaterialId);
                    tempList.Add(baseOfMaterial);

                }
                
            }
            typeOfMaterial.BaseOfMaterialList = tempList;


            return typeOfMaterial;
        }
        [HttpPost]
        public async Task<IActionResult> Create(TypeOfMaterial typeOfMaterial)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            await _tomService.CreateAsync(typeOfMaterial);
            return Ok(typeOfMaterial);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var typeOfMaterial = await _tomService.GetByIdAsync(id);
            if(typeOfMaterial == null)
            {
                return NotFound();
            }
            await _tomService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, TypeOfMaterial typeOfMaterial)
        {
            var typeOfMaterialOrigin = await _tomService.GetByIdAsync(id);
            if(typeOfMaterialOrigin == null)
            {
                return NotFound();
            }
            await _tomService.UpdateAsync(id, typeOfMaterial);
            return Ok(typeOfMaterial);
            //return no content

        }
    }
}
