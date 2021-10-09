using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Data.Repository.Base;

namespace Trading.Data.Repository
{
    public class UserRepository : AbstractBaseRepository<User, int>
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async override Task<User> GetAsync(int id)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async override Task<List<User>> GetAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public async Task<User> GetByLoginAndPasswordAsync(string login, string password) 
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }
    }
}
