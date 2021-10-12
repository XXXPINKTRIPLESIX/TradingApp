using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Interfaces;
using Microsoft.Extensions.Configuration;
using Trading.DTO.Response.Fiat;
using Trading.DTO.Request;
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

        public async Task<CoupledResponseDTO> ExchangeAsync(FiatRequestExchangeDTO requestDTO)
        {
            StringBuilder urlBuilder = new StringBuilder(_configuration["FiatApi:BaseUrl"]);
            urlBuilder.Append(_configuration["FiatApi:Key"]);
            urlBuilder.Append("/pair/");
            urlBuilder.Append(requestDTO.BaseCurrency + "/");
            urlBuilder.Append(requestDTO.TargetCurrency + "/");
            urlBuilder.Append(requestDTO.Amount);

            using(HttpResponseMessage response = await _httpClient.GetAsync(urlBuilder.ToString()))
            {
                if (response.IsSuccessStatusCode)
                    return new CoupledResponseDTO() { SuccessResponse = await response.Content.ReadAsAsync<FiatResponseDTO>(), ErrorResponse = null };
                else
                    return new CoupledResponseDTO() { SuccessResponse = null, ErrorResponse = await response.Content.ReadAsAsync<FiatResponseErrorDto>() };
            }
        }

        public async Task<CoupledResponseDTO> RatesAsync(string baseCurrencyCode)
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
                    return new CoupledResponseDTO() { SuccessResponse = res, ErrorResponse = null };
                }
                else
                    return new CoupledResponseDTO() { SuccessResponse = null, ErrorResponse = await response.Content.ReadAsAsync<FiatResponseErrorDto>() };
            }
        }
    }
}
