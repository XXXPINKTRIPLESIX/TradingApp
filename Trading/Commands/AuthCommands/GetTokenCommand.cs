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
        public AuthRequestDTO AuthDTO { get;}

        public GetTokenCommand(AuthRequestDTO authDTO)
        {
            AuthDTO = authDTO;
        }
    }
}
