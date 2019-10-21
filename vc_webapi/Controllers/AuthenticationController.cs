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
        private readonly Vc_webapiContext modelDb;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IJWTTokenGenerator tokenGenerator;

        public AuthenticationController(Vc_webapiContext modelDb, UserManager<IdentityUser> userManager, IJWTTokenGenerator tokenGenerator)
        {
            this.modelDb = modelDb;
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthenticationResponse), 200)]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            if(user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                var claims = await userManager.GetClaimsAsync(user);
                var token = tokenGenerator.GenerateToken(claims);
                return Ok(new AuthenticationResponse() {Token = token, UserName = login.UserName });
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(IdentityResult), 200)]
        public async Task<IActionResult> RegisterUser([FromBody] UserSignupModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.Password) || string.IsNullOrEmpty(userModel.UserName))
                return BadRequest();

            var createUserResult = await userManager.CreateAsync(new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.UserName
            }, userModel.Password);

            if (createUserResult.Succeeded)
            {
                var user = await userManager.FindByNameAsync(userModel.UserName);
                await userManager.AddClaimsAsync(user, new[] { new Claim("UserId", user.Id), new Claim("UserName", user.UserName) });

                //Decoupling domain users from Identity framework, by correlating a domain user with the identity.
                modelDb.Users.Add(new Student
                {
                    UserName = user.UserName, //correlation
                    Email = userModel.Email,
                    FullName = userModel.FullName,
                });
                await modelDb.SaveChangesAsync();
            }
            return Ok(createUserResult);
        }
    }
}