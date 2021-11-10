using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Common;
using Trading.Data.Models;

namespace Trading.Commands.CurrencyCommands
{
    public class ExchangeFiatCurrencyCommand : IRequest<ExecutionResult<Account>>
    {
        public int AccountId { get; set; }
        public int TargetAccountId { get; set; }
        public double Amount { get; set; }
    }
}
