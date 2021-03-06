using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.UserCommands;
using Trading.Data.Models;
using Trading.Queries.UserQueries;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetUsersQuery());

            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;

            return StatusCode(code, res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetUserQuery query)
        {
            var res = await _mediator.Send(query);

            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;

            return StatusCode(code, res);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand command)
        {
            var res = await _mediator.Send(command);

            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            
            return StatusCode(code, res);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var res = await _mediator.Send(command);
            
            var code = res ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest;

            return StatusCode(code);
        }

        [HttpPatch]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var res = await _mediator.Send(command);

            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            
            return StatusCode(code, res);
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPersonalData([FromBody] AddPersonalDataCommand command) 
        {
            var res = await _mediator.Send(command);

            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

            return StatusCode(code, res);
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePersonalData([FromBody] UpdateUserCommand command)
        {
            var res = await _mediator.Send(command);

            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;

            return StatusCode(code, res);
        }
    }
}
