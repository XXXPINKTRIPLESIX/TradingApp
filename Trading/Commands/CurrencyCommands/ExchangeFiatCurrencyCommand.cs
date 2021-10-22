using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Fiat;

namespace Trading.Commands.CurrencyCommands
{
    public class ExchangeFiatCurrencyCommand : IRequest<FiatApiResponseDTO>
    {
        public int AccountId { get; set; }
        public int TargetAccountId { get; set; }
        public double Amount { get; set; }
    }
}
