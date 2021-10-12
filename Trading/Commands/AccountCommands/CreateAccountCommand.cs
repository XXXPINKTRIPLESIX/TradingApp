using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.AccountCommands
{
    public class CreateAccountCommand : IRequest<bool>
    {
        public Account Account { get; }

        public CreateAccountCommand(Account account)
        {
            Account = account;
        }
    }
}
