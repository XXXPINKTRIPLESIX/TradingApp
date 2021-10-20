using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Crypro;

namespace Trading.Commands.CurrencyCommands
{
    public class ExchangeCryptoCurrencyCommand : IRequest<CryptoResponseExchangeDTO>
    {
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public double Amount { get; set; }
    }
}
