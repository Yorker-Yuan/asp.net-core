using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPIInAngular.Models;

namespace WebAPIInAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST: api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(CApplicationUser c)
        {
            var applicationuser = new ApplicationUser() {
                //此處對應到IdentityUser
                UserName = c.UserName,
                Email = c.Email,
                FullName = c.FullName
            };
            try
            {
                var result = await _userManager.CreateAsync(applicationuser,c.Password);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(CLogin login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var tokenDescripter = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim("UserID", user.Id.ToString())
                 }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescripter);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }else
            {
                return BadRequest(new { message ="使用者名稱或密碼錯誤"});
            }
        }
    }
}
