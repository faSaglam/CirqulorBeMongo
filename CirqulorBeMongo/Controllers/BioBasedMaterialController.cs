
using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BioBasedMaterialController : ControllerBase
    {
        private readonly BioBasedMaterialService _bbmService;
        private readonly TypeOfMaterialService _tomService;
        public BioBasedMaterialController(BioBasedMaterialService bbmService , TypeOfMaterialService tomService)
        {
            _bbmService = bbmService;
            _tomService = tomService;
        }

        [HttpGet]
        public async Task<List<BioBasedMaterial>> Get()=> await _bbmService.GetAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<BioBasedMaterial>> Get(string id)
        {
            var bioBasedMaterial = await _bbmService.GetByIdAsync(id);
            if (bioBasedMaterial is null)
            {
                return NotFound();
            }

            var tempList = new List<TypeOfMaterial>();
            foreach(var typeOfMaterialId in bioBasedMaterial.TypeOfMaterials)
            {
                var typeOfMaterial = await _tomService.GetByIdAsync(typeOfMaterialId);
                
                if(typeOfMaterial != null) { tempList.Add(typeOfMaterial); }
           
                
            }
            bioBasedMaterial.TypeOfMaterialList = tempList;

         
            return bioBasedMaterial;
        }
        [HttpPost]
        public async Task<IActionResult> Post(BioBasedMaterial newBioBasedMaterial)
        {
            await _bbmService.CreateAsync(newBioBasedMaterial);

            return CreatedAtAction(nameof(Get), new { id = newBioBasedMaterial.Id }, newBioBasedMaterial);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, BioBasedMaterial updatedBioBasedMaterial)
        {
            var bioBasedMaterial = await _bbmService.GetByIdAsync(id);

            if (bioBasedMaterial is null)
            {
                return NotFound();
            }

            updatedBioBasedMaterial.Id = bioBasedMaterial.Id;

            await _bbmService.UpdateAsync(id, updatedBioBasedMaterial);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var bioBasedMaterial = await _bbmService.GetByIdAsync(id);

            if (bioBasedMaterial is null)
            {
                return NotFound();
            }

            await _bbmService.RemoveAsync(id);

            return NoContent();
        }

    }
}
