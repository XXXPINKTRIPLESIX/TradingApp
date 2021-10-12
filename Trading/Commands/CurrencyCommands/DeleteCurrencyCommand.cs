using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Commands.CurrencyCommands
{
    public class DeleteCurrencyCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteCurrencyCommand(int id)
        {
            Id = id;
        }
    }
}
