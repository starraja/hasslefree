using hasslefreeAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace hasslefreeAPI.Services
{
    public interface IUserService
    {
        //        UserDto Authenticate(string username, string password);
        //        IEnumerable<UserDto> GetAllUsers();
        //        UserDto CreateUser(CreateUserDto createUser);
        UserDto GenerateJwtToken(IdentityUser user);
        void SendConfirmationEmail(string token,string email, string username);
    }
}
