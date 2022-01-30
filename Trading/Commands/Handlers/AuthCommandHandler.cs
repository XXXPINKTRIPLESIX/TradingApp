using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Commands.AuthCommands;
using Trading.Interfaces;
using Trading.Services;

namespace Trading.Commands.Handlers
{
    public class AuthCommandHandler : IRequestHandler<GetTokenCommand, object>
    {
        private readonly IAuthService _authService;

        public AuthCommandHandler(IAuthService service) => _authService = service;

        public async Task<object> Handle(GetTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authService.GetTokenAsync(request.Login, request.Password);
        }
    }
}
