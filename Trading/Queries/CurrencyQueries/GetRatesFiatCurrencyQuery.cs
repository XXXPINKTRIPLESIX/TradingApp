using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Common;
using Trading.DTO.Fiat;

namespace Trading.Queries.CurrencyQueries
{
    public class GetRatesFiatCurrencyQuery : IRequest<ExecutionResult<FiatResponseDTO>>
    {
        public string BaseCurrency { get; set; }
    }
}
