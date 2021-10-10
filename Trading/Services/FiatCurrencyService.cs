using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Interfaces;
using Microsoft.Extensions.Configuration;
using Trading.DTO.Response.Fiat;

namespace Trading.Services
{
    public class FiatCurrencyService : IService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public FiatCurrencyService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _httpClient = clientFactory.CreateClient();
        }

        public async Task<CoupledResponseDTO> ExchangeAsync(string baseCurrencyCode, string subCurrencyCode, double amount = 1)
        {
            string url = $"{_configuration["FiatApi:BaseUrl"]}{_configuration["FiatApi:Key"]}/pair/{baseCurrencyCode}/{subCurrencyCode}/{amount}";

            using(HttpResponseMessage response = await _httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                    return new CoupledResponseDTO() { SuccessResponse = await response.Content.ReadAsAsync<FiatResponseDTO>(), ErrorResponse = null };
                else
                    return new CoupledResponseDTO() { SuccessResponse = null, ErrorResponse = await response.Content.ReadAsAsync<FiatResponseErrorDto>() };
            }
        }

        public async Task<CoupledResponseDTO> RatesAsync(string baseCurrencyCode)
        {
            string url = $"{_configuration["FiatApi:BaseUrl"]}{_configuration["FiatApi:Key"]}/latest/{baseCurrencyCode}";

            using (HttpResponseMessage response = await _httpClient.GetAsync(url)) 
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<FiatResponseDTO>();
                    res.ConversionRates.Remove(baseCurrencyCode);
                    return new CoupledResponseDTO() { SuccessResponse = res, ErrorResponse = null };
                }
                else
                    return new CoupledResponseDTO() { SuccessResponse = null, ErrorResponse = await response.Content.ReadAsAsync<FiatResponseErrorDto>() };
            }
        }
    }
}
