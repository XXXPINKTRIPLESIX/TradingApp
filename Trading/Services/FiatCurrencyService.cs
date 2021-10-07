using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Trading.DTO.Response.Fiat;

namespace Trading.Services
{
    public class FiatCurrencyService : ICurrencyService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public FiatCurrencyService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _httpClient = clientFactory.CreateClient();
        }

        public async Task<FiatResponseExchangeDTO> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount = 1)
        {
            string url = $"{_configuration["FiatApi:BaseUrl"]}{_configuration["FiatApi:Key"]}/pair/{baseCurrencyCode}/{subCurrencyCode}/{amount}";

            using(HttpResponseMessage response = await _httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<FiatResponseExchangeDTO>();
                else
                    throw new NotImplementedException();
            }
        }

        public async Task<FiatResponseRateDTO> Rates(string baseCurrencyCode)
        {
            string url = $"{_configuration["FiatApi:BaseUrl"]}{_configuration["FiatApi:Key"]}/latest/{baseCurrencyCode}";

            using (HttpResponseMessage response = await _httpClient.GetAsync(url)) 
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<FiatResponseRateDTO>();
                else
                    throw new NotImplementedException();
            }
        }
    }
}
