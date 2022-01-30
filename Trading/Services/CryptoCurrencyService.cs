using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Trading.Common;
using Trading.DTO.Crypro;
using Trading.Interfaces;
using Trading.OptionBinders;

namespace Trading.Services
{
    public class CryptoCurrencyService : ICryptoService
    {
        private readonly HttpClient _httpClient;

        public CryptoCurrencyService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();

            var options = configuration.GetSection(CryptoApiOptions.CryptoApi).Get<CryptoApiOptions>();

            _httpClient.BaseAddress = new Uri(options.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add(options.Header, options.Key);
        }

        public async Task<ExecutionResult> ExchangeAsync(string baseCurrencyCode, string targetCurrency, double amount)
        {
            var url = $"exchangerate/" +
                $"{baseCurrencyCode}/" +
                $"{targetCurrency}";

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(requestMessage);

            return response.IsSuccessStatusCode 
                ? ExecutionResult<CryptoResponseDTO>.CreateSuccess(await response.Content.ReadAsAsync<CryptoResponseDTO>()) 
                : ExecutionResult.CreateError(await response.Content.ReadAsAsync<string>());
        }

        public async Task<ExecutionResult> GetRatesAsync(string baseCurrencyCode)
        {
            var url = $"exchangerate/" +
                $"{baseCurrencyCode}/" +
                "?invert=false";

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            
            var response = await _httpClient.SendAsync(requestMessage);

            return response.IsSuccessStatusCode ? 
                ExecutionResult<List<CryptoResponseDTO>>.CreateSuccess(await response.Content.ReadAsAsync<List<CryptoResponseDTO>>()) 
                : ExecutionResult.CreateError(await response.Content.ReadAsAsync<string>());
        }
    }
}
