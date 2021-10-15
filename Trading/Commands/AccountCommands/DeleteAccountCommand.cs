using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.AccountCommands
{
    public class DeleteAccountCommand : IRequest<Account>
    {
        public int Id { get; set; }
    }
}
