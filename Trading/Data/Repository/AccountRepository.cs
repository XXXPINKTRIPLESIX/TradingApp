using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Data.Repository.Base;

namespace Trading.Data.Repository
{
    public class AccountRepository : AbstractBaseRepository<Account, int>
    {
        public AccountRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async override Task<Account> GetAsync(int id)
        {
            return await _databaseContext.Accounts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async override Task<List<Account>> GetAsync()
        {
            return await _databaseContext.Accounts.ToListAsync();
        }
    }
}
