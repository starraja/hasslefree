using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace hasslefreeAPI.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public IEnumerable<IdentityError> IdentityError { get; set; }
        public IEnumerable<string> SignInErrors { get; set; }
    }
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserMailConfirmDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
