using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsOfProducerController : ControllerBase
    {
        private readonly MaterialsOfProducerService _mopService;
        private readonly NameOfMaterialService _nameOfMaterialService;
        private readonly UserManager<ApplicationUser> _userManager;
        public MaterialsOfProducerController(
            MaterialsOfProducerService mopService,
            NameOfMaterialService nameOfMaterialService,
            UserManager<ApplicationUser> userManager
            )
        {
            _mopService = mopService;
            _nameOfMaterialService = nameOfMaterialService;
            _userManager = userManager;
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
            if(mop == null ) { return NotFound(); }
            if(mop.Producer == null)
            {
                return NotFound();

            }
            var producer = await _userManager.FindByIdAsync(mop.Producer.ToString());
            mop.ProducerName = producer.UserName;
            var nameofmaterial = await _nameOfMaterialService.GetAsyncById(mop.NameOfMaterial);
            mop.NameOfMaterialName = nameofmaterial.Name;

            
            return Ok(mop); 

        }
        [HttpGet("/nameofmaterials/{name}/producer/{producername}")]
        public async Task<List<MaterialsOfProducer>> GetListByNomId(string name,string producername)
        {
            var mopList = await _mopService.GetAsync();
            var tempList = new List<MaterialsOfProducer>();
            foreach(var item in mopList)
            {
                if (item.Id != null)
                {
                    var mop = await _mopService.GetByIdAsync(item.Id);
                    var nom = await _nameOfMaterialService.GetAsyncById(mop.NameOfMaterial);
                    mop.NameOfMaterialName = nom.Name;
                    var producer = await _userManager.FindByNameAsync(producername);
                    if(producer == null) {  mop.ProducerName = "no user"; }
                    mop.ProducerName = producer.UserName;
                    if(mop.NameOfMaterialName == name && mop.ProducerName == producername)
                    {
                        tempList.Add(mop);
                    }
                 
                }
             
            }
            mopList = tempList;
            return mopList.ToList();
            

        }
        [HttpPost]
        public async Task<ActionResult<MaterialsOfProducer>> PostAsync(MaterialsOfProducer newMop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             await _mopService.CreateAsync(newMop);

            if(newMop.NameOfMaterial == null)
            {
                return NoContent();
            }
            var nameOfMaterial = await _nameOfMaterialService.GetAsyncById(newMop.NameOfMaterial);
            if (nameOfMaterial == null)
            {
                return NoContent();
            }
         
            nameOfMaterial.MaterialOfSuppliers.Add(newMop.Id);

            NameOfMaterial nomToUpdate = new NameOfMaterial()
            {
                Id = nameOfMaterial.Id,
                Name = nameOfMaterial.Name,
                BaseOfMaterials = nameOfMaterial.BaseOfMaterials,
                SourceOfMaterials = nameOfMaterial.SourceOfMaterials,
                BioBasedMaterials = nameOfMaterial.BioBasedMaterials,
                TypeOfMaterials = nameOfMaterial.TypeOfMaterials,
                MaterialOfSuppliers = nameOfMaterial.MaterialOfSuppliers
            };
            await _nameOfMaterialService.UpdateAsync(nameOfMaterial.Id, nomToUpdate);


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
