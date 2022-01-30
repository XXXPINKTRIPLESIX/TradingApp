using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Common;
using Trading.DTO.Crypro;

namespace Trading.Queries.CurrencyQueries
{
    public class GetRatesCryptoCurrencyQuery : IRequest<ExecutionResult>
    {
        public string BaseCurrency { get; set; }
    }
}
