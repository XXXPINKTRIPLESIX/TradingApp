using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Response.Crypro;

namespace Trading.Interfaces.Services
{
    public interface ICryptoCurrencyService
    {
        public Task<List<CryptoResponseExchangeDTO>> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount);
        public Task<CryproResponseRateDTO> GetRates(string baseCurrencyCode);
        public Task<List<CryptoResponseCoinsDTO>> GetCoinsList(string baseCurrencyCode);
    }
}
