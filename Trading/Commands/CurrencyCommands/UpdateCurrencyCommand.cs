using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.CurrencyCommands
{
    public class UpdateCurrencyCommand : IRequest<Currency>
    {
        public Currency Currency { get; }

        public UpdateCurrencyCommand(Currency currency)
        {
            Currency = currency;
        }
    }
}
