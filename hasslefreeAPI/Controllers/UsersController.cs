using hasslefreeAPI.Interface;
using hasslefreeAPI.Models;
using hasslefreeAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hasslefreeAPI.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly IUserService _userService;
        public UserController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            IEmailSender emailSender,
            IUserService userService
            )

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailSender = emailSender;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<UserDto> Login([FromBody] CreateUserDto model)
        {
            
            var result = await _signInManager.PasswordSignInAsync(model.LoginName, model.Password, false, false);

            if (result.Succeeded)
            {
                IdentityUser appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return _userService.GenerateJwtToken(model.Email, appUser);
            }
            if (result.IsNotAllowed) {
                return new UserDto { SignInErrors =new List<string> { "Email Verification Pending." } };
            }
            
            return new UserDto { SignInErrors = new List<string> { "UserName or Password is Invalid." } };
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto model)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = model.LoginName,
                Email = model.Email
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
           
            if (result.Succeeded)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                _userService.SendConfirmationEmail(token, user.Email);
                await _signInManager.SignInAsync(user, false);
                return _userService.GenerateJwtToken(model.Email, user);
            }

            return new UserDto { IdentityError = result.Errors };
        }
        [HttpPost("VerifyEmail")]
        public async Task<object> VerifyEmail([FromBody]string username, [FromBody]string emailtoken)
        {
            IdentityUser user = await _userManager.FindByNameAsync(username);

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, emailtoken);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Content("Email verified sucessfully");
            }

            return result.Errors;
        }

      

    }
}