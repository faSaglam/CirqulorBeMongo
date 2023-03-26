using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly ProductionService _productionService;
        public ProductionController(ProductionService productionService) 
        {
            _productionService = productionService;
        }
        [HttpGet]
        public async Task<List<Production>> GetAsync()
        {
            var productionList = await _productionService.GetAsync();
            return productionList;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Production>> GetAsyncById(string id)
        {
            var production = await _productionService.GetAsyncById(id);
            return Ok(production);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var production = await _productionService.GetAsyncById(id);
            if(production == null)
            {
                return NotFound();
            }
            await _productionService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id,Production updatedProduction)
        {
            var production = await _productionService.GetAsyncById(id);
            if(production == null)
            {
                return NotFound();
            }
            await _productionService.UpdateAsync(id, updatedProduction);
            return Ok(updatedProduction);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Production newProduction)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _productionService.CreateAsync(newProduction);
            return Ok(newProduction);
        }
    }
}
