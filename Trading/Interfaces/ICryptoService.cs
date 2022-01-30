using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Common;

namespace Trading.Interfaces
{
    public interface ICryptoService
    {
        public Task<ExecutionResult> ExchangeAsync(string baseCurrencyCode, string targetCurrency, double amount);
        public Task<ExecutionResult> GetRatesAsync(string baseCurrencyCode);
    }
}
