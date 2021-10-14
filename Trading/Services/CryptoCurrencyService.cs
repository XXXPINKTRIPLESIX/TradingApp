using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.DTO.Crypro;
using Trading.Interfaces;

namespace Trading.Services
{
    public class CryptoCurrencyService : IService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public CryptoCurrencyService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<CryptoResponseExchangeDTO>> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CryptoResponseCoinsDTO>> GetCoinsList(string baseCurrencyCode)
        {
            throw new NotImplementedException();
        }

        public async Task<CryproResponseRateDTO> GetRates(string baseCurrencyCode)
        {
            throw new NotImplementedException();
        }
    }
}
