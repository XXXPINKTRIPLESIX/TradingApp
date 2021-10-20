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
        private readonly HttpClient _httpClient;
        private readonly FiatApiOptions _options;

        public FiatCurrencyService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();

            _options = configuration.GetSection(FiatApiOptions.FiatApi).Get<FiatApiOptions>();

            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
        }

        public async Task<FiatApiResponseDTO> ExchangeAsync(string baseCurrency, string targetCurrency, double amount)
        {
            string url = $"{_options.Key}/" +
                "pair/" +
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

        public async Task<FiatApiResponseDTO> GatRatesAsync(string baseCurrency)
        {
            string url = $"{_options.Key}" +
                "/latest/" +
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
    }
}
