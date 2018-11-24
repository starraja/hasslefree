using hasslefreeAPI.Models;
using System.Collections.Generic;

namespace hasslefreeAPI.Services
{
    public interface IUserService
    {
        UserDto Authenticate(string username, string password);
        IEnumerable<UserDto> GetAllUsers();
        UserDto CreateUser(CreateUserDto createUser);
    }
}
