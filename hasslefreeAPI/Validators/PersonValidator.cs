using FluentValidation;
using hasslefreeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Validators
{

    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.LoginName).NotEmpty().Length(0, 50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.FirstName).NotEmpty().Length(0, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(0, 50);
            RuleFor(x => x.Password).NotEmpty().Length(0, 50);
        }
    }
}
