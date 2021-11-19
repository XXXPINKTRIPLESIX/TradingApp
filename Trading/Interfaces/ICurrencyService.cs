using System.Threading.Tasks;
using Trading.Common;
using Trading.DTO.Crypro;

namespace Trading.Interfaces
{
    public interface ICurrencyService<in T> where T : class
    {
        public Task<ExecutionResult> GetRatesAsync<U>(string baseCurrencyCode) where U : T;
        public Task<ExecutionResult> ExchangeAsync<U>(string baseCurrencyCode, string targetCurrency, double amount) where U : T;
    }
}