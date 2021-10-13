using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.AccountCommands
{
    public class UpdateAccountCommand : IRequest<Account>
    {
        public Account Account { get; }
        public UpdateAccountCommand(Account account)
        {
            Account = account;
        }
    }
}
