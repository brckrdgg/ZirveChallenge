using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Helpers;

namespace ZirveChallenge.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string username,string password);

        public  Task UserAdd(User user);
    }
}
