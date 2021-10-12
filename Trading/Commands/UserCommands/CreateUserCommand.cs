using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.UserCommands
{
    public class CreateUserCommand  : IRequest<bool>
    {
        public User User { get; }
        public CreateUserCommand(User user)
        {
            User = user;
        }
    }
}
