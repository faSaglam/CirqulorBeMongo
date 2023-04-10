using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SourceOfMaterialService _sourceService;
        private readonly NameOfMaterialService _nameOfMaterialService;
        //private readonly UserService _userService;
        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager ,
            SourceOfMaterialService sourceService,
            NameOfMaterialService nameOfMaterialService
            //,
            //UserService userService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _sourceService = sourceService;
            _nameOfMaterialService = nameOfMaterialService;
            //_userService = userService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var userList = await _userService.GetAsync();
        //    return Ok(userList);

        //}
        [HttpPost]
        public async Task<IActionResult> CreateAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ApplicationUser appUser = new ApplicationUser
            {
                UserName = user.Name,
                Email = user.Email,
                Company = user.Company,
                PhotoUrl = user.PhotoUrl,
                Country = user.Country,
                Address = user.Address,
                WebSite = user.WebSite,
                JobTittle = user.JobTittle

            };
            
         
            await _userManager.CreateAsync(appUser,user.Password);
            
            await _userManager.AddToRoleAsync(appUser, user.Role);



            return Ok(appUser);
        }
        [HttpPost("role")]
        
        public async Task<IActionResult> CreateRole(string name)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest();
            }
            ApplicationRole appRole = new ApplicationRole { Name = name };
            await _roleManager.CreateAsync(appRole);
            return Ok(appRole);
        }
        [HttpGet("role/{id}")]
        public async Task<ActionResult<ApplicationRole>> GetByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return Ok(role);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) { return NotFound(); }
            return Ok(user);
         
        }
        [HttpGet("source/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUserSourceById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); };
            var tempList = new List<SourceOfMaterial>();

            //if(user.SourceOfMaterials is not null)
            //{
            //    foreach (var somId in user.SourceOfMaterials)
            //    {
            //        if (somId != null)
            //        {
            //            var som = await _sourceService.GetAsyncById(somId);
            //            tempList.Add(som);
            //        }
                    
            //    }
            //    user.SourceOfMaterialList = tempList;

            //}
            return Ok(user);
        }
        [HttpGet("nameofmaterial/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUserNameOfMaterialsById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); };
            var tempList = new List<NameOfMaterial>();
            //if(user.NameOfMaterials is not null)
            //{
            //    foreach(var nomId in user.NameOfMaterials)
            //    {
            //        if(nomId != null) 
            //        {
            //            var nom = await _nameOfMaterialService.GetAsyncById(nomId);
            //            if(nom != null)
            //            {
            //                tempList.Add(nom);
            //            }
                        
            //        }
            //    }
            //    user.NameOfMaterialList = tempList;
            //}
            return Ok(user);
        }
        [HttpPut("addNameOfMaterial/{id}")]
        public async Task<IActionResult> AddNameOfMaterialToUser(string id, List<string> newMaterial)
        {
            var userOrigin = await _userManager.FindByIdAsync(id);
            if (userOrigin == null) 
            {
                return NotFound(); 
            }
            //userOrigin.NameOfMaterials = newMaterial;
            var result = await _userManager.UpdateAsync(userOrigin);
            if(result.Succeeded)
            {
                return Ok(userOrigin);
            }
            return BadRequest(result.Errors);
            
            //var app = new ApplicationUser
            //{ 
            //    NameOfMaterials = user.NameOfMaterials,
                
            //};
            //await _userManager.UpdateSecurityStampAsync(app);
            //var updateUser = await _userManager.UpdateAsync(app);
            
           
            //return Ok(updateUser);


        }
        [HttpPut("addSourceOfMaterial/{id}")]
        public async Task<IActionResult> AddSourceOfMaterialToUser(string id, List<string> newSource)
        {
            var userOrigin = await _userManager.FindByIdAsync(id);
            if (userOrigin == null)
            {
                return NotFound();
            }
            //userOrigin.SourceOfMaterials = newSource;
            var result = await _userManager.UpdateAsync(userOrigin);
            if (result.Succeeded)
            {
                return Ok(userOrigin);
            }
            return BadRequest(result.Errors);

            //var app = new ApplicationUser
            //{ 
            //    NameOfMaterials = user.NameOfMaterials,

            //};
            //await _userManager.UpdateSecurityStampAsync(app);
            //var updateUser = await _userManager.UpdateAsync(app);


            //return Ok(updateUser);


        }
    }
}
