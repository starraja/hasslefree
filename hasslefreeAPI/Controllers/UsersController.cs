using hasslefreeAPI.Entities;
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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly IUserService _userService;
        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
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
        public async Task<UserDto> Login([FromBody] CreateUserDto user)
        {
            
            var result = await _signInManager.PasswordSignInAsync(user.LoginName, user.Password, false, false);

            if (result.Succeeded)
            {
                ApplicationUser appUser = _userManager.Users.SingleOrDefault(r => r.UserName == user.LoginName);
                return _userService.GenerateJwtToken(appUser);
            }
            if (result.IsNotAllowed) {
                return new UserDto { SignInErrors =new List<string> { "Email Verification Pending." } };
            }
            
            return new UserDto { SignInErrors = new List<string> { "UserName or Password is Invalid." } };
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto user)
        {
            ApplicationUser iuser = new ApplicationUser
            {
                UserName = user.LoginName,
                Email = user.Email
            };
            IdentityResult result = await _userManager.CreateAsync(iuser, user.Password);
           
            if (result.Succeeded)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(iuser);
                _userService.SendConfirmationEmail(token, user.Email,user.LoginName);
                await _signInManager.SignInAsync(iuser, false);
                return _userService.GenerateJwtToken(iuser);
            }

            return new UserDto { IdentityError = result.Errors };
        }
        [HttpPost("VerifyEmail")]
        public async Task<object> VerifyEmail([FromBody]UserMailConfirmDto usermail)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(usermail.UserName);

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, usermail.Token);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Content("Email verified sucessfully");
            }

            return result.Errors;
        }

      

    }
}