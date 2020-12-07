using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPIInAngular.Models;

namespace WebAPIInAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST: api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(CApplicationUser c)
        {
            var applicationuser = new ApplicationUser() {
                UserName = c.fUserName,
                Email = c.fEmail,
                fFullName = c.fFullName
            };
            try
            {
                var result = await _userManager.CreateAsync(applicationuser,c.fPassword);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
