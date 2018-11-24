using hasslefreeAPI.Authorization;
using hasslefreeAPI.Models;
using hasslefreeAPI.Helpers;
using hasslefreeAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hasslefreeAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<UserDto> Authenticate([FromBody]CreateUserDto userParam)
        {
            var user = _userService.Authenticate(userParam.LoginName, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        [PermissionAttribute(PermissionType.View, 123)]
        [HttpGet("GetAllUsers")]
        public ActionResult<UserDto> GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpPost("CreateUsers")]
        public ActionResult<UserDto> CreateUser([FromBody]CreateUserDto createUser)
        {
            var user = _userService.CreateUser(createUser);
            return Ok(user);
        }
    }
}
