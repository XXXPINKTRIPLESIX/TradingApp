using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.CurrencyCommands
{
    public class CreateCurrencyCommand : IRequest<bool>
    {
        public string CurrencyCode { get; }
        public CurrencyType Type { get; }

        public CreateCurrencyCommand(string currencyCode, CurrencyType type)
        {
            CurrencyCode = currencyCode;
            Type = type;
        }
    }
}
