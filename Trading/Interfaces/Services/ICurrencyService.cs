using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Interfaces.Database;
using Trading.DTO.Response.Fiat;

namespace Trading.Interfaces.Services
{
    public interface ICurrencyService
    {
        Task<CoupledResponseDTO> Exchange(string baseCurrencyCode, string subCurrencyCode, double amount);
        Task<CoupledResponseDTO> Rates(string baseCurrencyCode);
    }
}
