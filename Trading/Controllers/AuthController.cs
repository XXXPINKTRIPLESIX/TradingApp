using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Commands.AuthCommands;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token([FromBody]GetTokenCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
