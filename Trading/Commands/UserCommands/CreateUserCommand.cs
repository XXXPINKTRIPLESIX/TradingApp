using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Commands.UserCommands
{
    public class CreateUserCommand  : IRequest<bool>
    {
        public string Login { get; }
        public string Password { get; }
        public string Email { get; }
        public string Role { get; }

        public CreateUserCommand(string login, string password, string email, string role)
        {
            Login = login;
            Password = password;
            Email = email;
            Role = role;
        }
    }
}
