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
        UserDto GenerateJwtToken(string email, IdentityUser user);
        void SendConfirmationEmail(string token,string email);
    }
}
