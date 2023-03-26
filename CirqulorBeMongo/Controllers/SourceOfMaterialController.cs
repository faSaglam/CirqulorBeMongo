using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceOfMaterialController : ControllerBase
    {
        private readonly SourceOfMaterialService _somService;
        private readonly UserManager<ApplicationUser> _userManager;
        public SourceOfMaterialController(
            SourceOfMaterialService somService, UserManager<ApplicationUser> userManager) 
        {
            _somService = somService; 
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<List<SourceOfMaterial>> GetAsync()
        {
            var som = await _somService.GetAsync();
            return som;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SourceOfMaterial>> GetAsyncById(string id)
        {
            var som = await _somService.GetAsyncById(id);
            var tempList = new List<ApplicationUser>();
            if(som.Users == null)
            {
                return som;
            }
            foreach(var userId in som.Users)
            {
                if(userId != null)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    tempList.Add(user);
                    
                }
            }
            som.UserList = tempList;
            return som;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var som = await _somService.GetAsyncById(id);
            if(som == null) 
            {
                return NotFound();
            }
            await _somService.RemoveAsync(id);
            return NoContent();

        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(SourceOfMaterial newSom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _somService.CreateAsync(newSom);
            return Ok(newSom);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id,SourceOfMaterial updatedSom)
        {
            var som = await _somService.GetAsyncById(id);
            if(som == null)
            {
                return NotFound();
            }
            await _somService.UpdateAsync(id, updatedSom);
            return Ok(updatedSom);
        }

    }
}
