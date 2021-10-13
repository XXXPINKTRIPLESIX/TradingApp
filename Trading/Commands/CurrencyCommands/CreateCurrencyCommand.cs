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
        //public Currency Currency { get; }
        public string CurrencyCode { get; set; }
        public List<Account> Accounts { get; set; }
        public CurrencyType Type { get; set; }

        public CreateCurrencyCommand(Currency currency)
        {
            Currency = currency;
        }
    }
}
