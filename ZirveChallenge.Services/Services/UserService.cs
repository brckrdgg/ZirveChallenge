using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Repositories;
using ZirveChallenge.Core.Services;
using ZirveChallenge.Core.UnitOfWorks;
using ZirveChallenge.Core.Helpers;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using ZirveChallenge.Core.Dto;

namespace ZirveChallenge.Services.Services
{
    public class UserService : Service<User>, IUserService
    {

        private readonly AppSettings _appSettings;

        public UserService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings, IRepository<User> repository) : base(unitOfWork, repository)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<LoginModel> Login(LoginDto loginDto)
        {

            string password = loginDto.Password.Encrypt();
            string username = loginDto.Username;
            User user= await _unitOfWork.User.Login( username, password);

            if (user == null)
                throw new System.ArgumentNullException("Kullanıcı adınızı ve şifrenizi kontrol ediniz");

            var tokenHandler = new JwtSecurityTokenHandler();
           
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
             
                Subject = new ClaimsIdentity(new[]
                {                  
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.Username)
                }),
                
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
           
            var token = tokenHandler.CreateToken(tokenDescriptor);          
            string generatedToken = tokenHandler.WriteToken(token);
            LoginModel loginModel = new LoginModel()
            {

                UserId = user.Id,
                UserName=username,
                Token = generatedToken,

            }; 
            return (loginModel);
        }
    

        public async Task<User> UserAdd(User user)
        {
               string pass = user.Password.Encrypt();
               user.Password = pass;
               await _unitOfWork.User.Insert(user);
               await _unitOfWork.CommitAsync();
               return user;

        }
    }

}
