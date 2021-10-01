using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Interfaces.Database;
using Trading.ResponseModels;

namespace Trading.Interfaces.Services
{
    public interface ICurrencyService
    {
        Task<ExchangeResponse> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount);
        Task<RatesResponse> Rates(string baseCurrencyCode);
    }
}
