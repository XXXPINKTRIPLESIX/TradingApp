using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Response.Fiat;

namespace Trading.Commands.CurrencyCommands
{
    public class ExchangeCurrencyCommand : IRequest<FiatApiResponseDTO>
    {
        public string BaseCurrency { get; }
        public string TargetCurrency { get; }
        public double Amount { get; }

        public ExchangeCurrencyCommand(string baseCurrency, string targetCurrency, double amount)
        {
            BaseCurrency = baseCurrency;
            TargetCurrency = targetCurrency;
            Amount = amount;
        }
    }
}
