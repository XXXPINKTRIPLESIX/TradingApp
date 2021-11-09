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
        private readonly CryptoApiOptions _options;

        public CryptoCurrencyService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();

            _options = configuration.GetSection(CryptoApiOptions.CryptoApi).Get<CryptoApiOptions>();

            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add(_options.Header, _options.Key);
        }

        public async Task<ExecutionResult<T>> ExchangeAsync<T>(string baseCurrencyCode, string targetCurrency, double amount)
        {
            string url = $"exchangerate/" +
                $"{baseCurrencyCode}/" +
                $"{targetCurrency}";

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    return ExecutionResult<T>.CreateSuccessResult(await response.Content.ReadAsAsync<T>());
                }
                else
                {
                    return ExecutionResult<T>.CreateErrorResult(await response.Content.ReadAsAsync<string>());
                }
            }
        }

        public async Task<ExecutionResult<List<T>>> GetRatesAsync<T>(string baseCurrencyCode)
        {
            string url = $"exchangerate/" +
                $"{baseCurrencyCode}/" +
                "?invert=false";
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    return ExecutionResult<List<T>>.CreateSuccessResult(await response.Content.ReadAsAsync<List<T>>());
                }
                else
                {
                    return ExecutionResult<List<T>>.CreateErrorResult(await response.Content.ReadAsAsync<string>());
                }
            }
        }
    }
}
