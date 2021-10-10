using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Interfaces
{
    public interface IRepository<T, TId> where T : class
    {
        public Task AddAsync(T t);
        public Task<T> GetAsync(TId id);
        public Task<List<T>> GetAsync();
        public Task<T> UpdateAsync(T t);
        public Task<T> DeleteAsync(T t);
        public Task<T> DeleteAsync(TId id);
    }
}
