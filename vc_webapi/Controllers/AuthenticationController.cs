using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using vc_webapi.Data;
using vc_webapi.Helpers;
using vc_webapi.Model;
using vc_webapi.Model.API;

namespace vc_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private AuthenticationContext db;
        private UserManager<User> userManager;
        private IJWTTokenGenerator tokenGenerator;

        public AuthenticationController(AuthenticationContext db, UserManager<User> userManager, IJWTTokenGenerator tokenGenerator)
        {
            this.db = db;
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthenticationResponse), 200)]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            var claims = await userManager.GetClaimsAsync(user);
            if(user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                var token = tokenGenerator.GenerateToken(claims);
                return Ok(new AuthenticationResponse() {Token = token, UserName = login.UserName });
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(IdentityResult), 200)]
        public async Task<IActionResult> RegisterUser([FromBody] UserSignupModel user)
        {
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.UserName))
                return BadRequest();

            var result = await userManager.CreateAsync(new User()
            {
                Email = user.EmailAddress,
                FullName = user.FullName,
                UserName = user.UserName
            }, user.Password);

            if (result.Succeeded)
            {
                var usr = await userManager.FindByNameAsync(user.UserName);
                await userManager.AddClaimAsync(usr, new Claim("UserID", usr.Id));
            }
            return Ok(result);
        }
    }
}