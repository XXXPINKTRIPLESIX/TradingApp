using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Crypro;

namespace Trading.Interfaces.Services
{
    public interface ICryptoCurrencyService
    {
        public Task<List<CryptoExchangeDTO>> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount);
        public Task<CryproRateDTO> GetRates(string baseCurrencyCode);
        public Task<List<CryptoCoinsDTO>> GetCoinsList(string baseCurrencyCode);
    }
}
