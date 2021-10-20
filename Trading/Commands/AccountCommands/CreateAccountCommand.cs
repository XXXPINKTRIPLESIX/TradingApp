using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Commands.AccountCommands
{
    public class CreateAccountCommand : IRequest<bool>
    {
        public int CurrencyId { get; set; }
        public int UserId { get; set; }
    }
}
