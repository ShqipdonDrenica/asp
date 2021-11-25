using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMIS.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {

        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController (UserManager<ApplicationUser> _userManager , SignInManager<ApplicationUser> _signInManager) {
            userManager = _userManager;
            signInManager = _signInManager;
        }


        [Route("GetUsers")]
        public IActionResult GetUsers() {

            var users = userManager.Users.ToList();
            if(users != null) {
                return Ok(users);
            }
            return new JsonResult("There are no users !");
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser model) {
            if (ModelState.IsValid) {
                var user = new ApplicationUser();
                user.Email = model.Email;
                user.UserName = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.BirthDate = model.BirthDate;
                
                //user.Address = model.Address;
                await userManager.CreateAsync(user, model.Password);
                return Ok();
            }
            return new JsonResult("Cannot create User");
        }

        [Route("Login")]
        public async Task<IActionResult> Login(ApplicationUser model) {
            if (ModelState.IsValid) {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true,false);
                if (result.Succeeded) {
                    return Ok("Logged In");
                }

                
                ModelState.AddModelError(string.Empty, "Invalid login attempt !");
                
            }
            return new JsonResult("Error !");
        }



    }
}
