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
using Trading.Common;

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

        public async Task<ExecutionResult> ExchangeAsync<T>(string baseCurrency, string targetCurrency, double amount) where T : FiatResponseDTO
        {
            var url = $"{_options.Key}/" +
                "pair/" +
                $"{baseCurrency}/" +
                $"{targetCurrency}/" +
                $"{amount}";

            using var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode 
                ? ExecutionResult<T>.CreateSuccessResult(await response.Content.ReadAsAsync<T>()) 
                : ExecutionResult.CreateErrorResult(await response.Content.ReadAsAsync<string>());
        }

        public async Task<ExecutionResult> GatRatesAsync<T>(string baseCurrency) where T : FiatResponseDTO
        {
            var url = $"{_options.Key}" +
                "/latest/" +
                $"{baseCurrency}";

            using var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsAsync<T>();
                res.ConversionRates.Remove(baseCurrency);
                
                return ExecutionResult<T>.CreateSuccessResult(res);
            }
            else
            {
                return ExecutionResult.CreateErrorResult(await response.Content.ReadAsAsync<string>());
            }
        }
    }
}
