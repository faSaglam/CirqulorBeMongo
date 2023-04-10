using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsOfProducerController : ControllerBase
    {
        private readonly MaterialsOfProducerService _mopService;
        public MaterialsOfProducerController(MaterialsOfProducerService mopService)
        {
            _mopService = mopService;
        }
        [HttpGet]
        public async Task<List<MaterialsOfProducer>> GetListAsync()
        {
            var mopList = await _mopService.GetAsync();
            return mopList;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialsOfProducer>> GetById(string id)
        {
            var mop = await _mopService.GetByIdAsync(id);
            return Ok(mop); 

        }
        [HttpPost]
        public async Task<ActionResult<MaterialsOfProducer>> PostAsync(MaterialsOfProducer newMop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _mopService.CreateAsync(newMop);
            return Ok(newMop);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var mop = await _mopService.GetByIdAsync(id);
            if (mop == null)
            {
                return NotFound();
            }
            await _mopService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<NameOfMaterial>> UpdateAsync(string id, MaterialsOfProducer mop)
        {
            var mopOrigin = await _mopService.GetByIdAsync(id);
            if (mopOrigin == null)
            {
                return NotFound();
            }
            await _mopService.UpdateAsync(id, mop);
            return Ok(mop);
        }
    }
}
