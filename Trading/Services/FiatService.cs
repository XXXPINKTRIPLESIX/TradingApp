using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Interfaces.Services;
using Trading.ResponseModels;
using Trading.Helpers;

namespace Trading.Services
{
    public class FiatService : ICurrencyService
    {
        public async Task<ExchangeResponse> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount = 1)
        {
            string url = $"{Constants.Constants.baseExchangeRateUrl}{Constants.Constants.key}/{baseCurrencyCode}/{subCurrencyCode}/{amount}";

            using(HttpResponseMessage response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<ExchangeResponse>();
                else
                    throw new NotImplementedException();

            }
        }

        public async Task<RatesResponse> Rates(string baseCurrencyCode)
        {
            string url = $"{Constants.Constants.baseExchangeRateUrl}{Constants.Constants.key}{baseCurrencyCode}";

            using(HttpResponseMessage response = await ApiHelper.Client.GetAsync(url)) 
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<RatesResponse>();
                else
                    throw new NotImplementedException();
            }
        }
    }
}
