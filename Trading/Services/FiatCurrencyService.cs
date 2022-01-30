﻿using System;
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
    public class FiatCurrencyService : ICurrencyService<FiatResponseDTO>
    {
        private readonly HttpClient _httpClient;
        private readonly FiatApiOptions _options;

        public FiatCurrencyService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();

            _options = configuration.GetSection(FiatApiOptions.FiatApi).Get<FiatApiOptions>();

            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
        }

<<<<<<< HEAD
        public async Task<ExecutionResult> ExchangeAsync(string baseCurrency, string targetCurrency, double amount)
=======
        public async Task<ExecutionResult> ExchangeAsync<T>(string baseCurrency, string targetCurrency, double amount) where T : FiatResponseDTO
>>>>>>> 49fbae1b169b8d35e3920b48a9599495e5d661a6
        {
            var url = $"{_options.Key}/" +
                "pair/" +
                $"{baseCurrency}/" +
                $"{targetCurrency}/" +
                $"{amount}";

            using var response = await _httpClient.GetAsync(url);
<<<<<<< HEAD
            return response.IsSuccessStatusCode
                ? ExecutionResult<FiatResponseDTO>.CreateSuccess(await response.Content.ReadAsAsync<FiatResponseDTO>())
                : ExecutionResult.CreateError(await response.Content.ReadAsAsync<string>());
        }

        public async Task<ExecutionResult> GatRatesAsync(string baseCurrency)
=======
            return response.IsSuccessStatusCode 
                ? ExecutionResult<FiatResponseDTO>.CreateSuccessResult(await response.Content.ReadAsAsync<FiatResponseDTO>()) 
                : ExecutionResult.CreateErrorResult(await response.Content.ReadAsAsync<string>());
        }

        public async Task<ExecutionResult> GetRatesAsync<T>(string baseCurrencyCode) where T : FiatResponseDTO
>>>>>>> 49fbae1b169b8d35e3920b48a9599495e5d661a6
        {
            var url = $"{_options.Key}" +
                "/latest/" +
                $"{baseCurrencyCode}";

            using var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
<<<<<<< HEAD
                var res = await response.Content.ReadAsAsync<FiatResponseDTO>();
                res.ConversionRates.Remove(baseCurrency);

                return ExecutionResult<FiatResponseDTO>.CreateSuccess(res);
            }
            else
                return ExecutionResult.CreateError(await response.Content.ReadAsAsync<string>());
=======
                var res = await response.Content.ReadAsAsync<T>();
                res.ConversionRates.Remove(baseCurrencyCode);
                
                return ExecutionResult<T>.CreateSuccessResult(res);
            }
            else
            {
                return ExecutionResult.CreateErrorResult(await response.Content.ReadAsAsync<string>());
            }
>>>>>>> 49fbae1b169b8d35e3920b48a9599495e5d661a6
        }
    }
}
