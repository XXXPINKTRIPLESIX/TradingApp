using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public User User { get; }
        public UpdateUserCommand(User user)
        {
            User = user;
        }
    }
}
