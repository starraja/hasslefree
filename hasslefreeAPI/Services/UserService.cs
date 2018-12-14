using AutoMapper;
using hasslefreeAPI.Entities;
using hasslefreeAPI.Helpers;
using hasslefreeAPI.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace hasslefreeAPI.Services
{

    public class UserService : IUserService
    {
        private readonly HassleFreeContext _context;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration, HassleFreeContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        //public UserDto Authenticate(string username, string password)
        //{
        //    UserDto user = _mapper.Map<UserDto>(_context.UserMaster.
        //        SingleOrDefault(x => x.LoginName == username && x.Password == password));

        //    // return null if user not found
        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    // authentication successful so generate jwt token
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.UserId.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    user.Token = tokenHandler.WriteToken(token);

        //    return user;
        //}

        //public UserDto CreateUser(CreateUserDto createUser)
        //{
        //    UserMaster user = _mapper.Map<UserMaster>(createUser);

        //    user.CreatedDateTime = DateTime.Now;
        //    user.ModifiedDateTime = DateTime.Now;

        //    _context.UserMaster.Add(user);
        //    //user.CreatedBy = user.UserId;
        //    //user.ModifiedBy = user.UserId;

        //    _context.SaveChanges();

        //    return _mapper.Map<UserDto>(_context.UserMaster.
        //       SingleOrDefault(x => x.LoginName == createUser.LoginName && x.Password == createUser.Password));
        //}

        //public IEnumerable<UserDto> GetAllUsers()
        //{
        //    // return users without passwords
        //    return _mapper.Map<UserDto[]>(_context.UserMaster.ToArray());
        //}
        public UserDto GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            UserDto userdto = new UserDto { FirstName = user.UserName };
            userdto.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return userdto;
        }

        public void SendConfirmationEmail(string Token, string email, string username)
        {
            try
            {
                SmtpClient client = new SmtpClient("mail.karkatharmatrimony.com");
                client.UseDefaultCredentials = false;
                client.EnableSsl = false;
                client.Port = 587;
                client.Credentials = new NetworkCredential("administrator@hasslefreecrm.com", "Asdf@123");
                string body = string.Empty;
                //using streamreader for reading my htmltemplate   

                using (StreamReader reader = new StreamReader("./Templates/EmailTemplate.html"))

                {

                    body = reader.ReadToEnd();

                }

                body = body.Replace("{{emaillink}}", "http://localhost:4200/auth/mail-confirm?username="
                    + Convert.ToBase64String(Encoding.UTF8.GetBytes(username)) + 
                    "&token=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(Token)));
                body = body.Replace("[USER NAME]", username);

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("administrator@hasslefreecrm.com");
                mailMessage.To.Add(email);
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "subject";
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
