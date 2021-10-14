using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Interfaces;
using Microsoft.Extensions.Configuration;
using Trading.DTO.Response.Fiat;
using System.Text;

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

        public async Task<FiatApiResponseDTO> ExchangeAsync(string baseCurrency, string targetCurrency, double amount)
        {
            StringBuilder urlBuilder = new StringBuilder(_configuration["FiatApi:BaseUrl"]);
            urlBuilder.Append(_configuration["FiatApi:Key"]);
            urlBuilder.Append("/pair/");
            urlBuilder.Append(baseCurrency + "/");
            urlBuilder.Append(targetCurrency + "/");
            urlBuilder.Append(amount);

            using (HttpResponseMessage response = await _httpClient.GetAsync(urlBuilder.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    return new FiatApiResponseDTO() { SuccessResponse = await response.Content.ReadAsAsync<FiatResponseDTO>(), ErrorResponse = null };
                }
                else
                {
                    return new FiatApiResponseDTO() { SuccessResponse = null, ErrorResponse = await response.Content.ReadAsAsync<FiatResponseErrorDto>() };
                }
            }
        }

        public async Task<FiatApiResponseDTO> RatesAsync(string baseCurrencyCode)
        {
            StringBuilder urlBuilder = new StringBuilder(_configuration["FiatApi:BaseUrl"]);
            urlBuilder.Append(_configuration["FiatApi:Key"] + "/");
            urlBuilder.Append("latest/");
            urlBuilder.Append(baseCurrencyCode);

            using (HttpResponseMessage response = await _httpClient.GetAsync(urlBuilder.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<FiatResponseDTO>();
                    res.ConversionRates.Remove(baseCurrencyCode);
                    return new FiatApiResponseDTO() { SuccessResponse = res, ErrorResponse = null };
                }
                else
                {
                    return new FiatApiResponseDTO() { SuccessResponse = null, ErrorResponse = await response.Content.ReadAsAsync<FiatResponseErrorDto>() };
                }
            }
        }
    }
}
