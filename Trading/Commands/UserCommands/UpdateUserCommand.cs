using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; }
        public string Password { get; }
        public string  Email { get; }
        public string Role { get; }

        public UpdateUserCommand(int id, string password, string email, string role)
        {
            Id = id;
            Password = password;
            Email = email;
            Role = role;
        }
    }
}
