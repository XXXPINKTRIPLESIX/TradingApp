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
        public Currency Currency { get; }

        public CreateCurrencyCommand(Currency currency)
        {
            Currency = currency;
        }
    }
}
