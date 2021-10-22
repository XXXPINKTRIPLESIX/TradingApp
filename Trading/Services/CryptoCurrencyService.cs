using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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

        public async Task<CryptoApiResponseDTO> ExchangeAsync(string baseCurrencyCode, string targetCurrency, double amount)
        {
            string url = $"exchangerate/" +
                $"{baseCurrencyCode}/" +
                $"{targetCurrency}";

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
            {
                //requestMessage.Headers.Authorization = new AuthenticationHeaderValue(_options.Header, _options.Key);

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    return new CryptoApiResponseDTO() { SuccessResponse = await response.Content.ReadAsAsync<CryptoResponseExchangeDTO>(), ErrorResponse = null };
                }
                else
                {
                    return new CryptoApiResponseDTO() { SuccessResponse = null, ErrorResponse = await response.Content.ReadAsAsync<CryptoResponseErrorDTO>() };
                }
            }
        }

        public async Task<List<CryptoResponseRatesDTO>> GetRatesAsync(string baseCurrencyCode)
        {
            string url = $"exchangerate/" +
                $"{baseCurrencyCode}/" +
                "?invert=false";
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
            {
                //requestMessage.Headers.Authorization = new AuthenticationHeaderValue(_options.Header, _options.Key);

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<CryptoResponseRatesDTO>>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
