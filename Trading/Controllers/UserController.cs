using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.UserCommands;
using Trading.Queries.UserQueries;
using Trading.Utils;

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
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetUsersQuery());

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetUserQuery query)
        {
            var res = await _mediator.Send(query);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand command)
        {
            var res = await _mediator.Send(command);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var res = await _mediator.Send(command);
            var code = res ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest;

            return StatusCode(code);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var res = await _mediator.Send(command);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonalData([FromBody] AddPersonalDataCommand command) 
        {
            var res = await _mediator.Send(command);

            if(res == null) 
            {
                return BadRequest();
            }

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonalData([FromBody] UpdateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
