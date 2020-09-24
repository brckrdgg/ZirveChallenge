using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Repositories;

namespace ZirveChallenge.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<User> Login(string username, string password)
        {
           
            var list= await GetAllAsync();
            return list.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }

        public async Task UserAdd(User user)
        {
            
             await Insert(user);
           
        }
    }
}
