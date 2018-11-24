using hasslefreeAPI.Models;
using hasslefreeAPI.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hasslefreeAPI.Entities;
using AutoMapper;

namespace hasslefreeAPI.Services
{

    public class UserService : IUserService
    {
        private readonly HassleFreeContext _context;

        private readonly IMapper _mapper;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, HassleFreeContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        public UserDto Authenticate(string username, string password)
        {
            UserDto user = _mapper.Map<UserDto>(_context.UserMaster.
                SingleOrDefault(x => x.LoginName == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public UserDto CreateUser(CreateUserDto createUser)
        {
            UserMaster user = _mapper.Map<UserMaster>(createUser);

            user.CreatedDateTime = DateTime.Now;
            user.ModifiedDateTime = DateTime.Now;

            _context.UserMaster.Add(user);

            //user.CreatedBy = user.UserId;
            //user.ModifiedBy = user.UserId;

            _context.SaveChanges();

            return _mapper.Map<UserDto>(_context.UserMaster.
               SingleOrDefault(x => x.LoginName == createUser.LoginName && x.Password == createUser.Password));
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            // return users without passwords
            return _mapper.Map<UserDto[]>(_context.UserMaster.ToArray());
        }
    }
}
