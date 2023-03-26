using CirqulorBeMongo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CirqulorBeMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        
       
        public async Task<IActionResult> Login(string email,  string password)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser appUser=await _userManager.FindByEmailAsync(email);
                if(appUser != null)
                {
                     var result =  await _signInManager.PasswordSignInAsync(appUser, password, false, false); 
                     if (result.Succeeded)
                     {
                        return Ok(appUser);
                     }
                 
                }
            }
            return BadRequest();
        }
    }
}
