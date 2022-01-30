using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Common;
using Trading.Data.Models;
using Trading.DTO.Crypro;

namespace Trading.Commands.CurrencyCommands
{
<<<<<<< HEAD
    public class ExchangeCryptoCurrencyCommand : IRequest<ExecutionResult>
=======
    public class ExchangeCryptoCurrencyCommand : IRequest<ExecutionResult<Account>>
>>>>>>> 49fbae1b169b8d35e3920b48a9599495e5d661a6
    {
        public int AccountId { get; set; }
        public int TargetAccountId { get; set; }
        public double Amount { get; set; }
    }
}
