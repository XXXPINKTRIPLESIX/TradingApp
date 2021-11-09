using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.AccountCommands;
using Trading.Data.Models;
using Trading.Queries.AccountQueries;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public AccountController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetAccountsQuery());
            
            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            
            return StatusCode(code, res);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Account), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetAccountQuery query)
        {
            var res = await _mediator.Send(query);
            
            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;
            
            return StatusCode(code, res);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAccountCommand command)
        {
            var res = await _mediator.Send(command);
            
            var code = res ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

            return StatusCode(code, res);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Account), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] DeleteAccountCommand command)
        {
            var res = await _mediator.Send(command);
            
            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;

            return StatusCode(code, res);
        }
    }
}
