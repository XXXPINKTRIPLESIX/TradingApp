using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Commands.AccountCommands
{
    public class DeleteAccountCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteAccountCommand(int id)
        {
            Id = id;
        }
    }
}
