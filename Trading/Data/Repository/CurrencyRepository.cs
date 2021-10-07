using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Data.Repository.Base;

namespace Trading.Data.Repository
{
    public class CurrencyRepository : AbstractBaseRepository<Currency, int>
    {
        public CurrencyRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async override Task<Currency> GetAsync(int id)
        {
            return await _databaseContext.Currencies.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async override Task<List<Currency>> GetAsync()
        {
            return await _databaseContext.Currencies.ToListAsync();
        }
    }
}
