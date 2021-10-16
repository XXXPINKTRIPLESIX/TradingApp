using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Crypro;

namespace Trading.Queries.CurrencyQueries
{
    public class GetRatesCryptoCurrencyQuery : IRequest<List<CryptoResponseRatesDTO>>
    {
        public string BaseCurrency { get; set; }
    }
}
