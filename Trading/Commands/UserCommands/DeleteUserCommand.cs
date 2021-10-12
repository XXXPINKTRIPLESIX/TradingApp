using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
