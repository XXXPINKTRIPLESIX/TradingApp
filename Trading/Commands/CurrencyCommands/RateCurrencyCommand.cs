using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Response.Fiat;

namespace Trading.Commands.CurrencyCommands
{
    public class RateCurrencyCommand : IRequest<CoupledResponseDTO>
    {
        public string BaseCurrency { get; }

        public RateCurrencyCommand(string baseCurrency)
        {
            BaseCurrency = baseCurrency;
        }
    }
}
