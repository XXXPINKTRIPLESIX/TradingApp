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

        public async Task<T> DeleteAsync(T t)
        {
            if (t == null)
                return null;

            _databaseContext.Entry(t).State = EntityState.Deleted;
            await _databaseContext.SaveChangesAsync();

            return t;
        }

        public async Task<T> DeleteAsync(TId id)
        {
            T entity = await GetAsync(id);

            if (entity == null)
                return null;

            _databaseContext.Entry(entity).State = EntityState.Deleted;
            await _databaseContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T t)
        {
            if (t == null)
                return null;

            _databaseContext.Entry(t).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();

            return t;
        }
    }
}
