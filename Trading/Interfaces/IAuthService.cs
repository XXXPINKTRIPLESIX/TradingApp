using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Interfaces
{
    public interface IAuthService
    {
        public Task<object> GetTokenAsync(string login, string password);
    }
}
