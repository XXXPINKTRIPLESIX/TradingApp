using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Interfaces.Database
{
    public interface IRepository<T, TId> where T : class
    {
        public Task Add(T t);
        public Task<T> Get(TId id);
        public Task<List<T>> Get();
        public Task Update(T t);
        public Task Delete(T t);
        public Task Delete(TId id);
    }
}
