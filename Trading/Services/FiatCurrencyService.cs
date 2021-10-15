using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Interfaces;
using Microsoft.Extensions.Configuration;
using Trading.DTO.Fiat;
using System.Text;
using Trading.OptionBinders;
using System.Net.Http.Headers;

namespace Trading.Services
{
    public class FiatCurrencyService : IFiatService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public FiatCurrencyService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _httpClient = clientFactory.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<FiatApiResponseDTO> ExchangeAsync(string baseCurrency, string targetCurrency, double amount)
        {
            var options = GetOptions();

            string url = $"" +
                $"{options.BaseUrl}/" +
                $"{options.Key}" +
                $"/pair/" +
                $"{baseCurrency}/" +
                $"{targetCurrency}/" +
                $"{amount}";

            using (HttpResponseMessage response = await _httpClient.GetAsync(url))
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

        public async Task<FiatApiResponseDTO> RatesAsync(string baseCurrency)
        {
            var options = GetOptions();

            string url = $"" +
                $"{options.BaseUrl}/" +
                $"{options.Key}" +
                $"/latest/" +
                $"{baseCurrency}";

            using (HttpResponseMessage response = await _httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<FiatResponseDTO>();
                    res.ConversionRates.Remove(baseCurrency);
                    return new FiatApiResponseDTO() { SuccessResponse = res, ErrorResponse = null };
                }
                else
                {
                    return new FiatApiResponseDTO() { SuccessResponse = null, ErrorResponse = await response.Content.ReadAsAsync<FiatResponseErrorDto>() };
                }
            }
        }

        private FiatApiOptions GetOptions() 
        {
            var options = new FiatApiOptions();
            _configuration.GetSection(FiatApiOptions.FiatApi).Bind(options);

            return options;
        }

    }
}
