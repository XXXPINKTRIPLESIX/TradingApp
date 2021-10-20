using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.CurrencyCommands
{
    public class DeleteCurrencyCommand : IRequest<Currency>
    {
        public int Id { get; set; }
    }
}
