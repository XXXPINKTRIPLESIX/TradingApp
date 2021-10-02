using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Data.Repository.Base;

namespace Trading.Data.Repository
{
    public class BalanceRepository : AbstractBaseRepository<Balance, int>
    {
        public BalanceRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async override Task<Balance> GetAsync(int id)
        {
            return await _databaseContext.Balances.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async override Task<List<Balance>> GetAsync()
        {
            return await _databaseContext.Balances.ToListAsync();
        }
    }
}
