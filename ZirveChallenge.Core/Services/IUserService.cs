using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Dto;
using ZirveChallenge.Core.Entities;

namespace ZirveChallenge.Core.Services
{
    public interface IUserService: IService<User>
    {
        Task<LoginModel> Login(LoginDto loginDto);

        Task<User> UserAdd(User user);
    }

}
