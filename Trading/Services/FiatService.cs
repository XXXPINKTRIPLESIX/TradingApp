using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Interfaces.Services;

namespace Trading.Services
{
    public class FiatService : ICurrencyService<>
    {
        private static readonly HttpClient client;

        public Task<> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount)
        {
            throw new NotImplementedException();
        }

        public Task<> Rates(string baseCurrencyCode)
        {
            throw new NotImplementedException();
        }
    }
}
