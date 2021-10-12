using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Request;
using Trading.DTO.Response.Fiat;

namespace Trading.Commands.CurrencyCommands
{
    public class ExchangeCurrencyCommand : IRequest<CoupledResponseDTO>
    {
        public FiatRequestExchangeDTO RequestDTO { get; }

        public ExchangeCurrencyCommand(FiatRequestExchangeDTO requestDTO)
        {
            RequestDTO = requestDTO;
        }
    }
}
