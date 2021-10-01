using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Interfaces.Database;

namespace Trading.Interfaces.Services
{
    public interface ICurrencyService<T>
    {
        Task<T> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount);
        Task<T> Rates(string baseCurrencyCode);
    }
}
