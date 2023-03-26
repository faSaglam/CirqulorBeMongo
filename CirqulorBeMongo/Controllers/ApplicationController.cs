using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _applicationService;
        public ApplicationController(ApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        [HttpGet]
        public async Task<List<Application>> GetAsync()
        {
            var applicationList = await _applicationService.GetAsync();
            return applicationList;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetAsyncById(string id)
        {
            var application = await _applicationService.GetAsyncById(id);
            return Ok(application);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Application application)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _applicationService.CreateAsync(application);
            return Ok(application);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var application = await _applicationService.GetAsyncById(id);
            if(application == null)
            {
                return NotFound();
            }
            await _applicationService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, Application updatedApplication)
        {
            var application = await _applicationService.GetAsyncById(id);
            if(application == null) 
            {
                return NotFound();
            }
            await _applicationService.UpdateAsync(id, updatedApplication);
            return Ok(updatedApplication);
        }
    }
}
