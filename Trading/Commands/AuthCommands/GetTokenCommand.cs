using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Request;

namespace Trading.Commands.AuthCommands
{
    public class GetTokenCommand : IRequest<object>
    {
        public string Login { get; }
        public string Password { get; }

        public GetTokenCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
