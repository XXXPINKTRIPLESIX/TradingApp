using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Common;

namespace Trading.Interfaces
{
    public interface IFiatService
    {
        public Task<ExecutionResult> ExchangeAsync(string baseCurrency, string targetCurrency, double amount);
        public Task<ExecutionResult> GatRatesAsync(string baseCurrency);
    }
}
