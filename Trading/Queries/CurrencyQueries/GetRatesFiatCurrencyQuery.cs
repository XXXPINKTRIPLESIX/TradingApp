using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Fiat;

namespace Trading.Queries.CurrencyQueries
{
    public class GetRatesFiatCurrencyQuery : IRequest<FiatApiResponseDTO>
    {
        public string BaseCurrency { get; set; }
    }
}
