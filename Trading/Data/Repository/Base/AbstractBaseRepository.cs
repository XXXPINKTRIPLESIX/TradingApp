using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Interfaces.Database;
using Microsoft.EntityFrameworkCore;

namespace Trading.Data.Repository.Base
{
    public abstract class AbstractBaseRepository<T, TId> : IRepository<T, TId> where T : class
    {
        protected readonly DatabaseContext _databaseContext;

        public AbstractBaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public abstract Task<T> GetAsync(TId id);

        public abstract Task<List<T>> GetAsync();

        public async Task AddAsync(T t)
        {
            _databaseContext.Entry(t).State = EntityState.Added;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T t)
        {
            _databaseContext.Entry(t).State = EntityState.Deleted;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TId id)
        {
            _databaseContext.Entry(GetAsync(id)).State = EntityState.Deleted;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _databaseContext.Entry(t).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
        }
    }
}
