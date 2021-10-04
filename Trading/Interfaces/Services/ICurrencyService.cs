using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Interfaces.Database;
using Trading.DTO.Fiat;

namespace Trading.Interfaces.Services
{
    public interface ICurrencyService
    {
        Task<FiatExchangeDTO> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount);
        Task<FiatRateDTO> Rates(string baseCurrencyCode);
    }
}
