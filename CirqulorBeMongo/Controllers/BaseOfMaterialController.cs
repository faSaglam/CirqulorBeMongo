using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseOfMaterialController : ControllerBase
    {
        private readonly BaseOfMaterialService _bomService;
        private readonly NameOfMaterialService _nomService;
        public BaseOfMaterialController(BaseOfMaterialService bomService, NameOfMaterialService nomService) 
        {
            _bomService = bomService;
            _nomService = nomService;
        }
        [HttpGet]
        public async Task<List<BaseOfMaterial>> Get()
        {
            var baseOfMaterialList = await _bomService.GetAsync();

         
            return baseOfMaterialList;
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseOfMaterial>> GetAsync(string id)
        {
            var baseOfMaterial = await _bomService.GetByIdAsync(id);
            if(baseOfMaterial == null)
            {
                return NotFound();
            }

            var tempList = new List<NameOfMaterial>();
            if(baseOfMaterial.NameOfMaterials != null)
            {
                foreach (string nameOfMaterialId in baseOfMaterial.NameOfMaterials)
                {
                    if (nameOfMaterialId != null)
                    {
                        var nameOfMaterial = await _nomService.GetAsyncById(nameOfMaterialId);
                        if (nameOfMaterial != null)
                        {
                            tempList.Add(nameOfMaterial);
                        }

                    }


                }
                baseOfMaterial.NameOfMaterialList = tempList;
            }
     
            return baseOfMaterial;

        }
        [HttpPost]
        public async Task<IActionResult> Create(BaseOfMaterial baseOfMaterial)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _bomService.CreateAsync(baseOfMaterial);
            return Ok(baseOfMaterial);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var bom = await _bomService.GetByIdAsync(id);
            if(bom == null)
            {
                return NotFound();
            }
            await _bomService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id ,BaseOfMaterial updatedBom)
        {
            var bom = await _bomService.GetByIdAsync(id);
            if(bom == null)
            {
                return BadRequest();
            }
            await _bomService.UpdateAsync(id, updatedBom);
            return NoContent();
        }
    }
}
